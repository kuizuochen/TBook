Imports System
Imports System.Threading
Imports System.Windows.Controls
Imports Microsoft.Phone.Controls
Imports Microsoft.Phone.Shell
Imports Microsoft.Phone.Maps
Imports System.Device.Location
Imports Microsoft.Phone.Controls.Maps
Imports Microsoft.Phone.Maps.Controls

Partial Public Class MainPage
    Inherits PhoneApplicationPage

    ' Constructor
    Public Sub New()
        InitializeComponent()

        SupportedOrientations = SupportedPageOrientation.Portrait Or SupportedPageOrientation.Landscape

        ' Sample code to localize the ApplicationBar
        'BuildLocalizedApplicationBar()

    End Sub

    ' Sample code for building a localized ApplicationBar
    'Private Sub BuildLocalizedApplicationBar()
    '    ' Set the page's ApplicationBar to a new instance of ApplicationBar.
    '    ApplicationBar = New ApplicationBar()

    '    ' Create a new button and set the text value to the localized string from AppResources.
    '    Dim appBarButton As New ApplicationBarIconButton(New Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative))
    '    appBarButton.Text = AppResources.AppBarButtonText
    '    ApplicationBar.Buttons.Add(appBarButton)

    '    ' Create a new menu item with the localized string from AppResources.
    '    Dim appBarMenuItem As New ApplicationBarMenuItem(AppResources.AppBarMenuItemText)
    '    ApplicationBar.MenuItems.Add(appBarMenuItem)
    'End Sub

    Private Sub abtnDoTest_Click(sender As Object, e As EventArgs)


        mapMain.Center = New GeoCoordinate(25.034281, 121.47708)
        'mapMain.Center = New GeoCoordinate(37.808588, -122.4770175)
        'mapMain.Center = New GeoCoordinate(37.808588, -122.4770175)
        mapMain.ZoomLevel = 15



        Dim a As Integer = 10


    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        mapMain.Center = New GeoCoordinate(25.034281, 121.47708)
        'mapMain.Center = New GeoCoordinate(37.808588, -122.4770175)
        'mapMain.Center = New GeoCoordinate(37.808588, -122.4770175)
        mapMain.ZoomLevel = 15

        Dim aPushPin As New Toolkit.Pushpin()
        AddHandler aPushPin.Tap, AddressOf testPushPinTap

        aPushPin.GeoCoordinate = New GeoCoordinate(25.034281, 121.47708)
        aPushPin.Content = ""
        Dim OL1 As New MapOverlay

        OL1.Content = aPushPin
        OL1.GeoCoordinate = New GeoCoordinate(25.034281, 121.47708)

        Dim lay1 As New Microsoft.Phone.Maps.Controls.MapLayer()

        lay1.add(OL1)

        mapMain.Layers.Add(lay1)
    End Sub

    Private Sub testPushPinTap(sender As Object, e As Input.GestureEventArgs)
        ' CType(sender, Toolkit.Pushpin).Content = "晚安牙籤"

    End Sub

    Private Sub abtnDoTest2_Click(sender As Object, e As EventArgs)
        '  clsDatabaseIO.ReadKMLFromAsset("Assets/DefaultKML/2010.kml")

        clsDatabaseIO.CopyDefaultKMLToBookShelfFolder()

        clsDatabaseIO.ReadKML(clsGlobalVariables.gBookShelfFileFolderName + "2010.xml")
    End Sub
End Class