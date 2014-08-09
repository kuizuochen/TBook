Imports System.Device.Location

Public Class clsPlace
#Region "Variable"
    Private mName As String
    Private mSnippetList As List(Of clsDescription)
    Private mDescriptionList As List(Of clsDescription)
    Private mStyleUrl As String
    Private mPoint As GeoCoordinate
#End Region


    Public Sub New(tPlaceReader As XmlReader)
        mDescriptionList = New List(Of clsDescription)
        mSnippetList = New List(Of clsDescription)

        While tPlaceReader.Read()
            If tPlaceReader.IsStartElement Then
                Select Case tPlaceReader.Name.ToLower
                    Case "name"
                        mName = tPlaceReader.ReadElementContentAsString
                    Case "snippet"
                        mSnippetList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                    Case "description"
                        mDescriptionList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                    Case "extendeddata"
                        mDescriptionList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                    Case "styleurl"
                        mStyleUrl = tPlaceReader.ReadElementContentAsString
                    Case "point"
                    Case "coordinates"
                        Dim _tempCoordinateString As String() = tPlaceReader.ReadElementContentAsString.Split(",")
                        mPoint = New GeoCoordinate(_tempCoordinateString(0), _tempCoordinateString(1), _tempCoordinateString(2))
                End Select
            End If
        End While
    End Sub
End Class
