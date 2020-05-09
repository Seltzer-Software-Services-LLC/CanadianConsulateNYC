Imports System.Configuration

Public Class AppServices
    Public WithEvents ThisUserLoginModel As UserLoginModel
    Public Sub New(_userLoginModel As UserLoginModel)
        ThisUserLoginModel = _userLoginModel
    End Sub
    Event FirstNameEnabledChanged(value As Boolean)
    Event LastNameEnabledChanged(value As Boolean)
    Event PasswordEnabledChanged(value As Boolean)
    Event SubmitEnabledChanged(value As Boolean)
    Event ReportDateEnabledChanged(value As Boolean)
    Public Function GetEmailInfo(ByRef emailSuffix As String, ByRef dlEmailAddress As String, ByRef EWS_URL As String, ByRef exchangeVersionOrdinal As Integer) As Boolean
        Dim result As Boolean = False
        Dim asr As AppSettingsReader
        Try
            asr = New AppSettingsReader()
            emailSuffix = asr.GetValue("emailSuffix", GetType(String))
            dlEmailAddress = asr.GetValue("dlEmailAddress", GetType(String))
            exchangeVersionOrdinal = asr.GetValue("exchangeVersionOrdinal", GetType(Integer))
            EWS_URL = asr.GetValue("EWS_URL", GetType(String))
        Catch ex As Exception

        End Try
        If emailSuffix.Trim <> "" AndAlso dlEmailAddress <> "" AndAlso EWS_URL.Trim <> "" AndAlso exchangeVersionOrdinal > 0 Then
            result = True
        End If
        Return result
    End Function
    'Public Function GetRedirectionURIScheme(ByRef redirectionURIScheme As String) As Boolean
    '    Dim result As Boolean = False
    '    Dim asr As AppSettingsReader
    '    Try
    '        asr = New AppSettingsReader()
    '        redirectionURIScheme = asr.GetValue("redirectionURIScheme", GetType(String))
    '    Catch ex As Exception

    '    End Try
    '    If redirectionURIScheme.Trim <> "" Then
    '        result = True
    '    End If
    '    Return result
    'End Function
    Public Function GetAdditionalSettings(ByRef htmlBodyType As Integer, ByRef numberOfDaysToAdd As Integer, ByRef recipients As String, ByRef subject As String, ByRef leaveIndicator As String, ByRef oooIndicator As String, ByRef visitorLogFolder As String, ByRef visitorLogFileName As String, ByRef fullNameColumn As Integer, ByRef functionalTitleColumn As Integer, ByRef departmentColumn As Integer, ByRef arrivalColumn As Integer, ByRef departureColumn As Integer, ByRef meetingColumn As Integer) As Boolean
        Dim result As Boolean = False
        Dim asr As AppSettingsReader
        Try
            asr = New AppSettingsReader()
            htmlBodyType = asr.GetValue("htmlBodyType", GetType(Integer))
            numberOfDaysToAdd = asr.GetValue("numberOfDaysToAdd", GetType(Integer))
            recipients = asr.GetValue("recipients", GetType(String))
            subject = asr.GetValue("subject", GetType(String))
            leaveIndicator = asr.GetValue("leaveIndicator", GetType(String))
            oooIndicator = asr.GetValue("oooIndicator", GetType(String))
            visitorLogFolder = asr.GetValue("visitorLogFolder", GetType(String))
            visitorLogFileName = asr.GetValue("visitorLogFileName", GetType(String))
            fullNameColumn = asr.GetValue("fullNameColumn", GetType(Integer))
            functionalTitleColumn = asr.GetValue("functionalTitleColumn", GetType(Integer))
            departmentColumn = asr.GetValue("departmentColumn", GetType(Integer))
            arrivalColumn = asr.GetValue("arrivalColumn", GetType(Integer))
            departureColumn = asr.GetValue("departureColumn", GetType(Integer))
            meetingColumn = asr.GetValue("meetingColumn", GetType(Integer))
            result = True
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function GenerateDailyTracker(firstNameText As String, lastNameText As String, unencryptedPasswordText As String, reportDateValue As DateTime) As Boolean
        Dim impersonationEmail As String = ""
        Dim emailSuffix As String = ""
        Dim redirectionURIScheme As String = ""
        Dim conn As PRMNYReporting.Exchange.CConnector = Nothing
        Dim iter As PRMNYReporting.Exchange.CIterator = Nothing
        Dim dlEmailAddress As String = ""
        Dim htmlBodyType As Integer
        Dim numberOfDaysToAdd As Integer
        Dim recipients As String = ""
        Dim subject As String = ""
        Dim htmlEmailBody As String = ""
        Dim recips() As String = Nothing
        Dim leaveIndicator As String = ""
        Dim oooIndicator As String = ""
        Dim visitorLogFolder As String = ""
        Dim visitorLogFileName As String = ""
        Dim fullNameColumn As Integer
        Dim functionalTitleColumn As Integer
        Dim departmentColumn As Integer
        Dim arrivalColumn As Integer
        Dim departureColumn As Integer
        Dim meetingColumn As Integer
        Dim EWS_URL As String = ""
        Dim exchangeVersionOrdinal As Integer = 0

        Dim eventList As New List(Of PRMNYReporting.Exchange.EventDetails)
        Dim sortedEventList As New List(Of String)
        Dim oooList As New List(Of String) 'list of e-mails of individuals who are out of the office
        Dim leaveList As New List(Of String) 'list of e-mails of individuals who are out on leave

        reportDateValue = CType(Format(reportDateValue, "yyyy-MM-dd"), DateTime)

        Dim msgSentOK As Boolean = False

        'validate entries;
        If ThisUserLoginModel.FirstNameText.Trim = "" OrElse
           ThisUserLoginModel.LastNameText.Trim = "" OrElse
           ThisUserLoginModel.UnencryptedPasswordText.Trim = "" Then
            'disable UI

            RaiseEvent FirstNameEnabledChanged(False)
            RaiseEvent LastNameEnabledChanged(False)
            RaiseEvent PasswordEnabledChanged(False)
            RaiseEvent SubmitEnabledChanged(False)
            RaiseEvent ReportDateEnabledChanged(False)
            Application.DoEvents()

            'Note: the call to the MsgBox function violates the strict MVP/MVVM design pattern
            MsgBox("Please review the values you have entered in the three input boxes.  One or more may be blank.", MsgBoxStyle.OkOnly, "Daily Tracker Report")

            're-enable UI
            RaiseEvent FirstNameEnabledChanged(True)
            RaiseEvent LastNameEnabledChanged(True)
            RaiseEvent PasswordEnabledChanged(True)
            RaiseEvent SubmitEnabledChanged(True)
            RaiseEvent ReportDateEnabledChanged(True)
            Application.DoEvents()
            Return msgSentOK
            Exit Function

        End If

        'begin processing

        RaiseEvent FirstNameEnabledChanged(False)
        RaiseEvent LastNameEnabledChanged(False)
        RaiseEvent PasswordEnabledChanged(False)
        RaiseEvent SubmitEnabledChanged(False)
        RaiseEvent ReportDateEnabledChanged(False)
        Application.DoEvents()

        Try
            'if entries are valid, get the e-mail suffix from the app.config file and generate the e-mail address;
            If GetEmailInfo(emailSuffix, dlEmailAddress, EWS_URL, exchangeVersionOrdinal) Then
                impersonationEmail = firstNameText & "." & lastNameText & emailSuffix
            End If
            conn = New PRMNYReporting.Exchange.CConnector(impersonationEmail, unencryptedPasswordText, EWS_URL, exchangeVersionOrdinal)
            iter = New PRMNYReporting.Exchange.CIterator(conn.ThisExchangeService, dlEmailAddress)
        Catch ex As Exception
            MsgBox("Application error: " & ex.Message, MsgBoxStyle.OkOnly, "Daily Tracker")
            Application.Exit()
        End Try

        If Not (IsNothing(conn)) Then
            If GetAdditionalSettings(htmlBodyType, numberOfDaysToAdd, recipients, subject, leaveIndicator, oooIndicator, visitorLogFolder, visitorLogFileName, fullNameColumn, functionalTitleColumn, departmentColumn, arrivalColumn, departureColumn, meetingColumn) Then

                'Get the calendar meetings for a given day for a set of e-mail addresses using delegate access;
                'Get the e-mail addresses of those who are out of the office or are on leave

                oooList.Clear()
                leaveList.Clear()

                Dim retval As Boolean
                retval = iter.GetDailyCalendarEntriesPerUser(conn.ThisExchangeService, iter.DistributionListEmails, impersonationEmail, unencryptedPasswordText, eventList, oooList, leaveList, numberOfDaysToAdd, leaveIndicator, oooIndicator, reportDateValue)


                Dim i As Integer
                For i = 0 To eventList.Count - 1
                    sortedEventList.Add(eventList(i).FormattedStartTime & "|" & eventList(i).FormattedEndTime & "|" & eventList(i).Subject & "|" & eventList(i).Location & "|" & eventList(i).AttendeeNames)
                Next i

                sortedEventList.Sort()
                oooList.Sort()
                leaveList.Sort()

                Dim visitor As New PRMNYReporting.Excel.CVisitor
                Dim visitorList As New List(Of PRMNYReporting.Excel.Visitor)
                visitor.GetVisitorData(visitorLogFolder, visitorLogFileName, visitorList, fullNameColumn, functionalTitleColumn, departmentColumn, arrivalColumn, departureColumn, meetingColumn, reportDateValue)

                'Construct an HTML e-mail containing the appropriate appointment information

                Dim renderer As New PRMNYReporting.Rendering.CRenderer

                htmlEmailBody = renderer.GenerateHTML(sortedEventList, oooList, leaveList, visitorList)

                'Send out the e-mails

                Dim sender As New PRMNYReporting.Exchange.CEmailer

                recips = recipients.Split("|")
                For Each recip As String In recips
                    Dim msg As New Microsoft.Exchange.WebServices.Data.EmailMessage(conn.ThisExchangeService)
                    Try
                        msgSentOK = sender.Send(msg, subject, recip, htmlEmailBody, htmlBodyType, reportDateValue)
                    Catch ex As Exception
                        msgSentOK = False
                    End Try
                Next
            End If
        End If
        'end processing
        're-enable UI
        RaiseEvent FirstNameEnabledChanged(True)
        RaiseEvent LastNameEnabledChanged(True)
        RaiseEvent PasswordEnabledChanged(True)
        RaiseEvent SubmitEnabledChanged(True)
        RaiseEvent ReportDateEnabledChanged(True)
        Application.DoEvents()
        Return msgSentOK

    End Function
End Class
