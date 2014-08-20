Imports System.Device.Location
Imports System.ComponentModel

Public Class clsPlace
    Implements INotifyPropertyChanged


#Region "Variable"
    Public Property pName As String
    Private mSnippetList As List(Of clsDescription)
    Private mDescriptionList As List(Of clsDescription)
    Private mStyleUrl As String
    Private mPoint As GeoCoordinate
#End Region


    Public Sub New()

    End Sub
    Public Sub New(tPlaceReader As XmlReader)
        mDescriptionList = New List(Of clsDescription)
        mSnippetList = New List(Of clsDescription)
        tPlaceReader.Read()
        Dim a As String = tPlaceReader.Name
        While tPlaceReader.Read()
            If tPlaceReader.IsStartElement Then

                Select Case tPlaceReader.Name.ToLower
                    Case "name"
                        pName = tPlaceReader.ReadElementContentAsString
                    Case "snippet"
                        mSnippetList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                    Case "description"
                        mDescriptionList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                        'Case "extendeddata"
                        '    mDescriptionList.Add(New clsDescription(tPlaceReader.ReadElementContentAsString))
                    Case "styleurl"
                        mStyleUrl = tPlaceReader.ReadElementContentAsString
                    Case "point"
                    Case "coordinates"
                        Dim _tempCoordinateString As String() = tPlaceReader.ReadElementContentAsString.Split(",")
                        mPoint = New GeoCoordinate(CDbl(_tempCoordinateString(1)), CDbl(_tempCoordinateString(0)), CDbl(_tempCoordinateString(2)))
                End Select
            End If
        End While
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
