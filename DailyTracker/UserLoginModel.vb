Public Class UserLoginModel
    Private _tbFirstNameText As String
    Private _tbLastNameText As String
    Private _tbUnencryptedPasswordText As String
    Private _dtpReportDate As DateTime
    Private _cmdSubmitEnabled As Boolean
    Private _tbFirstNameEnabled As Boolean
    Private _tbLastNameEnabled As Boolean
    Private _tbPasswordEnabled As Boolean
    Private _dtpReportDateEnabled As Boolean

    Public WithEvents ThisUserLoginController As UserLoginController 'can raise events in UserLoginController based on model changes
    Public WithEvents ThisAppServices As AppServices 'can respond to events raised by AppServices
    Event SendFirstNameEnabledStateToController(value As Boolean)
    Event SendLastNameEnabledStateToController(value As Boolean)
    Event SendPasswordEnabledStateToController(value As Boolean)
    Event SendSubmitEnabledStateToController(value As Boolean)
    Event SendReportDateEnabledStateToController(value As Boolean)

    Public Property FirstNameText As String
        Get
            Return _tbFirstNameText
        End Get
        Set(value As String)
            _tbFirstNameText = value
        End Set
    End Property
    Public Property LastNameText As String
        Get
            Return _tbLastNameText
        End Get
        Set(value As String)
            _tbLastNameText = value
        End Set
    End Property
    Public Property UnencryptedPasswordText As String
        Get
            Return _tbUnencryptedPasswordText
        End Get
        Set(value As String)
            _tbUnencryptedPasswordText = value
        End Set
    End Property
    Public Property ReportDateValue As DateTime
        Get
            Return _dtpReportDate
        End Get
        Set(value As DateTime)
            _dtpReportDate = value
        End Set
    End Property
    Public Property SubmitEnabled As Boolean
        Get
            Return _cmdSubmitEnabled
        End Get
        Set(value As Boolean)
            _cmdSubmitEnabled = value
        End Set
    End Property
    Public Property FirstNameEnabled As Boolean
        Get
            Return _tbFirstNameEnabled
        End Get
        Set(value As Boolean)
            _tbFirstNameEnabled = True

        End Set
    End Property
    Public Property LastNameEnabled As Boolean
        Get
            Return _tbLastNameEnabled
        End Get
        Set(value As Boolean)
            _tbLastNameEnabled = True

        End Set
    End Property
    Public Property PasswordEnabled As Boolean
        Get
            Return _tbPasswordEnabled
        End Get
        Set(value As Boolean)
            _tbPasswordEnabled = True
        End Set
    End Property
    Public Property ReportDateEnabled As Boolean
        Get
            Return _dtpReportDateEnabled
        End Get
        Set(value As Boolean)
            _dtpReportDateEnabled = value
        End Set
    End Property

    Public Sub New(userLoginController As UserLoginController)
        ThisUserLoginController = userLoginController
        ThisAppServices = New AppServices(Me)

        'to receive notifications from controller:
        AddHandler ThisUserLoginController.SendFirstNameToModel, AddressOf FirstNameChanged
        AddHandler ThisUserLoginController.SendLastNameToModel, AddressOf LastNameChanged
        AddHandler ThisUserLoginController.SendPasswordToModel, AddressOf PasswordChanged
        AddHandler ThisUserLoginController.SendSubmitClickToModel, AddressOf SubmitClicked
        AddHandler ThisUserLoginController.SendReportDateToModel, AddressOf ReportDateValueChanged

        FirstNameText = ""
        LastNameText = ""
        UnencryptedPasswordText = ""
        ReportDateValue = Today
        SubmitEnabled = True
        FirstNameEnabled = True
        LastNameEnabled = True
        PasswordEnabled = True
        ReportDateEnabled = True


        'to send notifications to app services:
        AddHandler ThisAppServices.FirstNameEnabledChanged, AddressOf FirstNameEnabledChanged
        AddHandler ThisAppServices.LastNameEnabledChanged, AddressOf LastNameEnabledChanged
        AddHandler ThisAppServices.PasswordEnabledChanged, AddressOf PasswordEnabledChanged
        AddHandler ThisAppServices.SubmitEnabledChanged, AddressOf SubmitEnabledChanged
        AddHandler ThisAppServices.ReportDateEnabledChanged, AddressOf ReportDateEnabledChanged

        'to send notifications back to controller:
        AddHandler ThisUserLoginController.EvtFirstNameEnabledStateChanged, AddressOf FirstNameEnabledChanged
        AddHandler ThisUserLoginController.EvtLastNameEnabledStateChanged, AddressOf LastNameEnabledChanged
        AddHandler ThisUserLoginController.EvtPasswordEnabledStateChanged, AddressOf PasswordEnabledChanged
        AddHandler ThisUserLoginController.EvtSubmitEnabledStateChanged, AddressOf SubmitEnabledChanged
        AddHandler ThisUserLoginController.EvtReportDateEnabledStateChanged, AddressOf ReportDateEnabledChanged

    End Sub
    Public Sub FirstNameChanged(newFirstName As String)
        Me.FirstNameText = newFirstName
    End Sub
    Public Sub LastNameChanged(newLastName As String)
        Me.LastNameText = newLastName
    End Sub
    Public Sub PasswordChanged(newPassword As String)
        Me.UnencryptedPasswordText = newPassword
    End Sub
    Public Sub ReportDateValueChanged(newDate As DateTime)
        Me.ReportDateValue = newDate
    End Sub

    Public Sub SubmitClicked()
        ThisAppServices.GenerateDailyTracker(Me.FirstNameText, Me.LastNameText, Me.UnencryptedPasswordText, Me.ReportDateValue)
    End Sub
    Public Sub FirstNameEnabledChanged(value As Boolean)
        Me.FirstNameEnabled = value
        RaiseEvent SendFirstNameEnabledStateToController(value)
    End Sub
    Public Sub LastNameEnabledChanged(value As Boolean)
        Me.LastNameEnabled = value
        RaiseEvent SendLastNameEnabledStateToController(value)
    End Sub
    Public Sub PasswordEnabledChanged(value As Boolean)
        Me.PasswordEnabled = value
        RaiseEvent SendPasswordEnabledStateToController(value)
    End Sub
    Public Sub SubmitEnabledChanged(value As Boolean)
        Me.SubmitEnabled = value
        RaiseEvent SendSubmitEnabledStateToController(value)
    End Sub
    Public Sub ReportDateEnabledChanged(value As Boolean)
        Me.ReportDateEnabled = value
        RaiseEvent SendReportDateEnabledStateToController(value)
    End Sub

End Class
