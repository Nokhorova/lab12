using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows;

namespace HotelProgram.ViewModels
{
    public class NewClientViewModel : ViewModelBase
    {
        public event Action RequestClose;
        private Hotel_bdEntities _context;
        private int _employee_id;

        public NewClientViewModel(Hotel_bdEntities context, int employeeId)
        {
            _context = context;
            _employee_id = employeeId;

            DocumentTypes = new ObservableCollection<document_types>();


            LoadDocumentTypes();
            LoadClients();

            SaveCommand = new RelayCommand(SaveClient);
        }
        public ObservableCollection<document_types> DocumentTypes { get; set; }
        private document_types _selectedDocumentType;
        public document_types SelectedDocumentType
        {
            get => _selectedDocumentType;
            set
            {
                _selectedDocumentType = value;
                OnPropertyChanged(nameof(SelectedDocumentType));
                if (_selectedDocumentType != null)
                {
                    DocumentTypeId = _selectedDocumentType.document_type_id;
                }
            }
        }

        private int _documentTypeId;
        public int DocumentTypeId
        {
            get
            {
                return _documentTypeId;
            }
            set
            {
                if (_documentTypeId != value)
                {
                    _documentTypeId = value;
                    OnPropertyChanged(nameof(DocumentTypeId));
                }
            }
        }
        public void LoadDocumentTypes()
        {
            DocumentTypes = new ObservableCollection<document_types>(_context.document_types.ToList());
        }
        private string _documentNumber;
        public string DocumentNumber
        {
            get
            {
                return _documentNumber;
            }
            set
            {
                if (_documentNumber != value)
                {
                    _documentNumber = value;
                    OnPropertyChanged(nameof(DocumentNumber));
                }
            }
        }
        private DateTime _documentDate;
        public DateTime DocumentDate
        {
            get
            {
                return _documentDate;
            }
            set
            {
                if (_documentDate != value)
                {
                    _documentDate = value;
                    OnPropertyChanged(nameof(DocumentDate));
                }
            }
        }

        public ObservableCollection<clients> Clients { get; set; }

        private clients _selectedClient;
        public clients SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (_selectedClient != value)
                {
                    _selectedClient = value;
                    OnPropertyChanged(nameof(SelectedClient));
                    if (_selectedClient != null)
                    {
                        ClientLastName = _selectedClient.client_lastname;
                        ClientName = _selectedClient.client_name;
                        ClientSurName = _selectedClient.client_surname;
                        ClientContactNumber = _selectedClient.client_contact_number;
                        ClientEmail = _selectedClient.client_email;
                        ClientAddress = _selectedClient.client_address;
                        var firstDocument = _selectedClient.documents.FirstOrDefault();
                        if (firstDocument != null)
                        {
                            SelectedDocumentType = firstDocument.document_types;
                            DocumentTypeId = firstDocument.document_type;
                            DocumentNumber = firstDocument.document_number;
                            DocumentDate = firstDocument.document_date;
                        }
                        else
                        {
                            ClearDocumentFields();
                        }
                    }
                }
                else
                {
                    ClearDocumentFields();
                }
            }
        }
        private void ClearDocumentFields()
        {
            SelectedDocumentType = null;
            DocumentTypeId = 0;
            DocumentNumber = string.Empty;
            DocumentDate = DateTime.Now;
        }
        private void LoadClients()
        {
            var clients = _context.clients
                .Include(c => c.client_rating)
                .Include(c => c.documents)
                .ToList();

            Clients = new ObservableCollection<clients>(clients);
        }
        private string _clientLastName;
        public string ClientLastName
        {
            get
            {
                return _clientLastName;
            }
            set
            {
                if (_clientLastName != value)
                {
                    _clientLastName = value;
                    OnPropertyChanged(nameof(ClientLastName));
                }
            }
        }

        private string _clientName;
        public string ClientName
        {
            get
            {
                return _clientName;
            }
            set
            {
                if (_clientName != value)
                {
                    _clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }
        private string _clientSurName;
        public string ClientSurName
        {
            get
            {
                return _clientSurName;
            }
            set
            {
                if (_clientSurName != value)
                {
                    _clientSurName = value;
                    OnPropertyChanged(nameof(ClientSurName));
                }
            }
        }
        private string _clientContactNumber;
        public string ClientContactNumber
        {
            get
            {
                return _clientContactNumber;
            }
            set
            {
                if (_clientContactNumber != value)
                {
                    _clientContactNumber = value;
                    OnPropertyChanged(nameof(ClientContactNumber));
                }
            }
        }
        private string _clientEmail;
        public string ClientEmail
        {
            get
            {
                return _clientEmail;
            }
            set
            {
                if (_clientEmail != value)
                {
                    _clientEmail = value;
                    OnPropertyChanged(nameof(ClientEmail));
                }
            }
        }
        private string _clientAddress;
        public string ClientAddress
        {
            get
            {
                return _clientAddress;
            }
            set
            {
                if (_clientAddress != value)
                {
                    _clientAddress = value;
                    OnPropertyChanged(nameof(ClientAddress));
                }
            }
        }
        // Команда для сохранения документа
        public ICommand SaveCommand { get; }

        private void SaveClient()
        {
            if (_selectedClient == null)
            {
                // Если клиент не выбран, создаем нового клиента и добавляем документ
                var newClient = new clients
                {
                    client_lastname = ClientLastName,
                    client_name = ClientName,
                    client_surname = ClientSurName,
                    client_contact_number = ClientContactNumber,
                    client_email = ClientEmail,
                    client_address = ClientAddress,
                    client_rating_id = 1
                };

                var newDocument = new documents
                {
                    document_type = DocumentTypeId,
                    document_number = DocumentNumber,
                    document_date = DocumentDate
                };

                newClient.documents.Add(newDocument);
                _context.clients.Add(newClient);
                LogTransaction(1, $"Клиент c # {newClient.client_id}");

            }
            else
            {
                // Если клиент выбран, проверяем и обновляем данные
                _selectedClient.client_lastname = ClientLastName;
                _selectedClient.client_name = ClientName;
                _selectedClient.client_surname = ClientSurName;
                _selectedClient.client_contact_number = ClientContactNumber;
                _selectedClient.client_email = ClientEmail;
                _selectedClient.client_address = ClientAddress;

                var document = _selectedClient.documents.FirstOrDefault();
                if (document == null)
                {
                    // Если у клиента нет документов, добавляем новый документ
                    document = new documents
                    {
                        client_id = _selectedClient.client_id,
                        document_type = DocumentTypeId,
                        document_number = DocumentNumber,
                        document_date = DocumentDate
                    };
                    _context.documents.Add(document);
                    _selectedClient.documents.Add(document);
                }
                else
                {
                    // Обновляем существующий документ
                    document.document_type = DocumentTypeId;
                    document.document_number = DocumentNumber;
                    document.document_date = DocumentDate;
                }
            }

            _context.SaveChanges();
            LoadClients(); // Обновляем список клиентов после сохранения
            LogTransaction(10, $"Данные клиента c # {_selectedClient.client_id}");
            RequestClose?.Invoke();
            MessageBox.Show("Клиент создан!");
        }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
            public void Execute(object parameter) => _execute();
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
        private void LogTransaction(int typeOperationId, string windowName)
        {
            var transaction = new transaction
            {
                employee_id = _employee_id,
                type_operation_id = typeOperationId,
                date = DateTime.Now,
                window_name = windowName
            };
            _context.transaction.Add(transaction);
            _context.SaveChanges();
        }
    }
}
