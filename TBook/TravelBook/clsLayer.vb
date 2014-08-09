Public Class clsLayer

#Region "Variables"
    Private mName As String
    Private mPlaceList As List(Of clsPlace)
#End Region

    Public Sub New(tXmlReader As XmlReader)
        mPlaceList = New List(Of clsPlace)

        While tXmlReader.Read()
            If tXmlReader.IsStartElement Then
                Select Case tXmlReader.Name.ToLower
                    Case "name"
                        mName = tXmlReader.ReadElementContentAsString
                    Case "placemark"
                        Dim _tempReader As XmlReader = tXmlReader.ReadSubtree()
                        tXmlReader.ReadInnerXml()
                        mPlaceList.Add(New clsPlace(_tempReader))
                End Select
            End If
        End While
    End Sub

    Public Sub New(tName As String, tPlaceList As List(Of clsPlace))
        mName = tName
        mPlaceList = New List(Of clsPlace)
        mPlaceList.AddRange(tPlaceList)
    End Sub
End Class
