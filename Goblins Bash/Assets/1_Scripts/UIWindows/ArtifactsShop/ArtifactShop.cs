using System.Linq;
using _1_Scripts.GameProgress;
using _1_Scripts.StaticData;
using _1_Scripts.UIModules;
using _1_Scripts.UIModules.ArtifactsShop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _1_Scripts.UIWindows
{
    public class ArtifactShop : UIWindow
    {
        [SerializeField] private Button backButton;
        
        [SerializeField] private ArtifactCellView[] artifactCells;

        [SerializeField] private ArtifactPanel artifactPanel;
        [SerializeField] private ArtifactPreviewPanel artifactPreviewPanel;
        
        private ArtifactsType[] _installedArtifacts;

        private bool _isCellSelected;
        private ArtifactCellView _selectedCell;

        private bool _isArtifactSelected;
        private ArtifactView _selectedArtifact;

        
        private IStaticDataService _staticDataService;
        private ProgressService _progressService;

        [Inject]
        public void Construct(IUIService uiService, IStaticDataService staticDataService, ProgressService progressService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService; ;
            
            backButton.onClick.AddListener(() => uiService.ReplaceWindow(WindowType.MainMenu));
            _installedArtifacts = new ArtifactsType[3];
        }


        public override void Show()
        {
            base.Show();
            
            ClearCells();
            
            artifactPanel.Initialize(_staticDataService.Artifacts, _progressService);
            artifactPanel.ArtifactViewClicked += OnArtifactViewClicked;
            artifactPanel.ArtifactViewDoubleClicked += OnArtifactViewDoubleClicked;

            _installedArtifacts = _progressService.SelectedArtifacts.ToArray();
            foreach (ArtifactCellView cell in artifactCells)
            {
                cell.OnClick += OnArtifactCellClicked;
            }

        }

        
        private void OnArtifactCellClicked(ArtifactCellView cell)
        {
            if (_selectedCell != cell || !_isCellSelected) SelectCell(cell);
            else if(_isCellSelected)
            {
                if (cell.IsOccupied) cell.UninstallArtifact();
                else cell.Unselect();
                
                _isCellSelected = false;
            }
        }
        
        
        
        
        
        private void OnArtifactViewClicked(ArtifactView artifact)
        {
            _selectedArtifact = artifact;
            artifactPreviewPanel.SetData(_selectedArtifact);
            
            if (_isCellSelected && !artifact.IsLock)
                PutArtifactInCell();
        }

        private void OnArtifactViewDoubleClicked(ArtifactView artifact)
        {
            GetFreeCell().InstallArtifact(artifact);
        }

        private ArtifactCellView GetFreeCell()
        {
            foreach (ArtifactCellView cell in artifactCells)
            {
                if (!cell.IsOccupied) return cell;
            }
            return null;
        }
        
        

        private void PutArtifactInCell()
        {
            _selectedCell.InstallArtifact(_selectedArtifact);
            _selectedCell.Unselect();
            _isCellSelected = false;
            _selectedArtifact.Select();
        }

        private void SelectCell(ArtifactCellView selectedCell)
        {
            foreach (ArtifactCellView cell in artifactCells)
            {
                cell.Unselect();
            }
            selectedCell.Select();
            _selectedCell = selectedCell;
            _isCellSelected = true;
            
            if(selectedCell.IsOccupied) artifactPreviewPanel.SetData(selectedCell.InstalledArtifact);
        }

        
        
        private void ClearCells()
        {
            foreach (ArtifactCellView cell in artifactCells)
            {
                if(cell.IsOccupied) cell.UninstallArtifact();
                cell.OnClick -= OnArtifactCellClicked;
            }
        }

        private void SaveInstalledArtifacts()
        {
            for (int i = 0; i < 3; i++)
            {
                _installedArtifacts[i] = (artifactCells[i].IsOccupied)
                    ? artifactCells[i].InstalledArtifact.ArtifactData.ArtifactId
                    : ArtifactsType.Empty;
            }
            _progressService.UpdateArtifacts(_installedArtifacts);
        }
        
        
        
        
        public override void Hide()
        {
            base.Hide();
            
            SaveInstalledArtifacts();
            artifactPanel.ArtifactViewClicked -= OnArtifactViewClicked;
            artifactPanel.ArtifactViewDoubleClicked -= OnArtifactViewDoubleClicked;
        }
    }
}