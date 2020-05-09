Imports PRMNYReporting.DailyTracker.Win


Public Class UserLoginController
    Public WithEvents ThisUserLoginView As UserLoginView 'can trap events from view
    Event SendFirstNameToModel(firstName As String)
    Event SendLastNameToModel(lastName As String)
    Event SendPasswordToModel(passWord As String)
    Event SendSubmitClickToModel()
    Event SendReportDateToModel(reportDate As DateTime)
    Event SendFirstNameEnabledChangeToView(value As Boolean)
    Event SendLastNameEnabledChangeToView(value As Boolean)
    Event SendPasswordEnabledChangeToView(value As Boolean)
    Event SendSubmitEnabledChangeToView(value As Boolean)
    Event SendReportDateEnabledChangeToView(value As Boolean)

    Public WithEvents ThisUserLoginModel As UserLoginModel 'can receive events from model
    Event EvtFirstNameEnabledStateChanged(value As Boolean)
    Event EvtLastNameEnabledStateChanged(value As Boolean)
    Event EvtPasswordEnabledStateChanged(value As Boolean)
    Event EvtSubmitEnabledStateChanged(value As Boolean)
    Event EvtReportDateEnabledStateChanged(value As Boolean)

    Public Sub New(userLoginView As UserLoginView)
        ThisUserLoginView = userLoginView
        ThisUserLoginModel = New UserLoginModel(Me)
        AddHandler ThisUserLoginView.tbFirstName.TextChanged, AddressOf FirstNameChanged
        AddHandler ThisUserLoginView.tbLastName.TextChanged, AddressOf LastNameChanged
        AddHandler ThisUserLoginView.tbPassword.TextChanged, AddressOf PasswordChanged
        AddHandler ThisUserLoginView.cmdSubmit.Click, AddressOf SubmitClicked
        AddHandler ThisUserLoginView.dtpReportDate.ValueChanged, AddressOf ReportDateValueChanged

        AddHandler ThisUserLoginModel.SendFirstNameEnabledStateToController, AddressOf FirstNameEnabledStateChanged
        AddHandler ThisUserLoginModel.SendLastNameEnabledStateToController, AddressOf LastNameEnabledStateChanged
        AddHandler ThisUserLoginModel.SendPasswordEnabledStateToController, AddressOf PasswordEnabledStateChanged
        AddHandler ThisUserLoginModel.SendSubmitEnabledStateToController, AddressOf SubmitEnabledStateChanged
        AddHandler ThisUserLoginModel.SendReportDateEnabledStateToController, AddressOf ReportDateEnabledStateChanged
    End Sub

    Public Sub FirstNameChanged()
        RaiseEvent SendFirstNameToModel(ThisUserLoginView.tbFirstName.Text)
    End Sub

    Public Sub LastNameChanged()
        RaiseEvent SendLastNameToModel(ThisUserLoginView.tbLastName.Text)
    End Sub

    Public Sub PasswordChanged()
        RaiseEvent SendPasswordToModel(ThisUserLoginView.tbPassword.Text)
    End Sub

    Public Sub SubmitClicked()
        RaiseEvent SendSubmitClickToModel()
    End Sub
    Public Sub ReportDateValueChanged()
        RaiseEvent SendReportDateToModel(ThisUserLoginView.dtpReportDate.Value)
    End Sub


    Public Sub FirstNameEnabledStateChanged(value As Boolean)
        ThisUserLoginView.tbFirstName.Enabled = value
    End Sub

    Public Sub LastNameEnabledStateChanged(value As Boolean)
        ThisUserLoginView.tbLastName.Enabled = value
    End Sub

    Public Sub PasswordEnabledStateChanged(value As Boolean)
        ThisUserLoginView.tbPassword.Enabled = value
    End Sub

    Public Sub SubmitEnabledStateChanged(value As Boolean)
        ThisUserLoginView.cmdSubmit.Enabled = value
    End Sub

    Public Sub ReportDateEnabledStateChanged(value As Boolean)
        ThisUserLoginView.dtpReportDate.Enabled = value
    End Sub


End Class
