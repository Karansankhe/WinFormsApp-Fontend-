Imports System.IO
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Text

Public Class FormViewSubmissions
    Private submissions As List(Of Submission)
    Private currentIndex As Integer = 0
    Private ReadOnly dbFilePath As String = Path.Combine(Application.StartupPath, "db.json")

    Private Async Sub FormViewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        submissions = LoadSubmissionsFromLocalDb()
        DisplaySubmission()
    End Sub

    Private Sub DisplaySubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 AndAlso currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            txtSubmissionName.Text = submissions(currentIndex).SubmissionName
            txtEmail.Text = submissions(currentIndex).Email
            txtPhoneNum.Text = submissions(currentIndex).PhoneNum
            txtGithubLink.Text = submissions(currentIndex).GithubLink
            txtStopwatchTime.Text = submissions(currentIndex).StopwatchTime
        Else
            ClearFields()
        End If
    End Sub

    Private Sub ClearFields()
        txtSubmissionName.Text = ""
        txtEmail.Text = ""
        txtPhoneNum.Text = ""
        txtGithubLink.Text = ""
        txtStopwatchTime.Text = ""
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        End If
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 AndAlso currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            Await DeleteSubmission(currentIndex)
            submissions.RemoveAt(currentIndex)
            If currentIndex >= submissions.Count Then
                currentIndex -= 1
            End If
            DisplaySubmission()
        End If
    End Sub

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If submissions IsNot Nothing AndAlso submissions.Count > 0 AndAlso currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            Await EditSubmission(currentIndex)
        End If
    End Sub

    Private Async Function DeleteSubmission(index As Integer) As Task
        Using httpClient As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await httpClient.DeleteAsync($"http://localhost:3000/delete?index={index}")
                response.EnsureSuccessStatusCode()
                MessageBox.Show("Submission deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to delete submission: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    Private Async Function EditSubmission(index As Integer) As Task
        Using httpClient As New HttpClient()
            Dim submissionData As New Dictionary(Of String, String) From {
                {"index", index.ToString()},
                {"SubmissionName", txtSubmissionName.Text},
                {"Email", txtEmail.Text},
                {"PhoneNum", txtPhoneNum.Text},
                {"GithubLink", txtGithubLink.Text},
                {"StopwatchTime", txtStopwatchTime.Text}
            }
            Dim json As String = JsonConvert.SerializeObject(submissionData)
            Dim content As New StringContent(json, Encoding.UTF8, "application/json")

            Try
                Dim response As HttpResponseMessage = Await httpClient.PutAsync("http://localhost:3000/edit", content)
                response.EnsureSuccessStatusCode()
                MessageBox.Show("Submission updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Update local submissions list after successful edit
                submissions(index).SubmissionName = txtSubmissionName.Text
                submissions(index).Email = txtEmail.Text
                submissions(index).PhoneNum = txtPhoneNum.Text
                submissions(index).GithubLink = txtGithubLink.Text
                submissions(index).StopwatchTime = txtStopwatchTime.Text

                SaveSubmissionsToLocalDb()
            Catch ex As Exception
                MessageBox.Show("Failed to update submission: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Function

    Private Function LoadSubmissionsFromLocalDb() As List(Of Submission)
        If File.Exists(dbFilePath) Then
            Dim json As String = File.ReadAllText(dbFilePath)
            Return JsonConvert.DeserializeObject(Of List(Of Submission))(json)
        Else
            Return New List(Of Submission)()
        End If
    End Function

    Private Sub SaveSubmissionsToLocalDb()
        Dim json As String = JsonConvert.SerializeObject(submissions, Formatting.Indented)
        File.WriteAllText(dbFilePath, json)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.D) Then
            btnDelete.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.E) Then
            btnEdit.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ' Placeholder for any additional event handling
    End Sub
End Class

Public Class Submission
    Public Property SubmissionName As String
    Public Property Email As String
    Public Property PhoneNum As String
    Public Property GithubLink As String
    Public Property StopwatchTime As String
End Class
