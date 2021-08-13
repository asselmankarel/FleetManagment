using Fleetmanagement.Admin.WPF.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fleetmanagement.Admin.WPF.ListViewModels
{
    public class RequestListViewModel : ObservableValidator
    {
        private RequestModel _selectedRequest;
        private readonly Services.RequestService _requestService;
        private bool _hasChanges;
        public ObservableCollection<RequestModel> Requests { get; set; } = new ObservableCollection<RequestModel>();

        public List<string> StatusTypes { get;  } = new List<string>()
        {
            "Created",
            "Processing",
            "Rejected",
            "Approuved",
            "Completed"
        };

        public RelayCommand SaveCommand { get; set; }

        public RequestListViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            _requestService = new Services.RequestService();
            LoadRequests();
        }


        public RequestModel SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                if (_selectedRequest != null) _selectedRequest.PropertyChanged -= SelectedRequestPropertyChanged;

                SetProperty(ref _selectedRequest, value, true);
                if (_selectedRequest != null)
                {
                    _hasChanges = false;
                    _selectedRequest.PropertyChanged += SelectedRequestPropertyChanged;
                }
            }
        }

        private async void OnSave()
        {
            var updateRequestResponse = await _requestService.UpdateRequestStatus(_selectedRequest);

            if (!updateRequestResponse.SuccessFul)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Failed to update request", "Error", System.Windows.MessageBoxButton.OK);
                LoadRequests();
            }

            _hasChanges = false;
        }

        private bool CanSave()
        {
            return _hasChanges;
        }

        private void SelectedRequestPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _hasChanges = true;
            SaveCommand.NotifyCanExecuteChanged();
        }

        private async void LoadRequests()
        {
            Requests.Clear();
            var requests = await _requestService.GetRequestsFromGrpcApi();
            requests.ForEach(r => Requests.Add(r));
        }
    }
}
