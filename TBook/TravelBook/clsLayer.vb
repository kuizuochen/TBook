Public Class clsLayer

#Region "Variables"
    Private mName As String
    Public _pPlaceList As List(Of clsPlace)
#End Region

    Public Sub New(tXmlReader As XmlReader)
        _pPlaceList = New List(Of clsPlace)

        While tXmlReader.Read()
            If tXmlReader.IsStartElement Then
                Select Case tXmlReader.Name.ToLower
                    Case "name"
                        mName = tXmlReader.ReadElementContentAsString
                    Case "placemark"
                        Dim _tempReader As XmlReader = tXmlReader.ReadSubtree()
                        tXmlReader.ReadInnerXml()
                        _pPlaceList.Add(New clsPlace(_tempReader))
                End Select
            End If
        End While
    End Sub

    Public Sub New(tName As String, tPlaceList As List(Of clsPlace))
        mName = tName
        _pPlaceList = New List(Of clsPlace)
        _pPlaceList.AddRange(tPlaceList)
    End Sub
End Class
