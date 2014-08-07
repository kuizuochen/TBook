Imports System.ComponentModel

Public Class clsBook
    Implements INotifyPropertyChanged

#Region "Variables"
    Private mName As String
    Private mDesctiptionList As List(Of clsDescription)
    Private mStyleList As List(Of clsPushPinStyle)
    Private mPlaceList As List(Of clsPlace)
#End Region

#Region "Variable"
    Public Property _pName As String 
        Get
            Return mName
        End Get
        Set(value As String)
            mName = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("_pName"))
        End Set
    End Property

#End Region


    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
