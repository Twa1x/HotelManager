   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager  5   	   A%clr-namespace:HotelManager.ViewModelsHotelManager.ViewModels  5   	   !    HotelManager.EmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HotelManager     5   	   <
viewmodels%clr-namespace:HotelManager.ViewModels     5   	     � Title$  EmployeeWindow��5	   	   $	��450��6    $	��800��6-   ��5      �� 5   
    �� ImageSource$' !/Resources/employeeBackground.jpg��6    j� Stretch$
 Fill=�6E    � DataContext 5      /   )HotelManager.ViewModels.EmployeeViewModel  5   
   .��5      � .+�5   
   �� $��Check Available Rooms��6F   $��581,183,78,193q�6f   ��6   �� *" GuestViewModel.CheckRoomsCommand+6f   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      $
��Left=�6%   $	��196��6@   $��
224,45,0,0q�6M   $	��Top=�6a   $	��327��6y      AutoGenerateColumns .  ��6�   �� *GuestViewModel.RoomsGuest+ �� SelectedItem 6�   �� *!GuestViewModel.CurrentRoomGuest+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$
 Type��67   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6�   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6E   �� *Type+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ Default=�6�     5       . $ Price��67   $		 100 6�   
 6F   �� *Price+$ OneWay=�$ Default=�6�      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      5      �� 5    
   $��Rooms Details��6   $��325,10,249,372q�6(   $��16(�6@   $��Bahnschrift)�6N   �� 5!   
   -   5        $��
DetailsBtn��5!   G   {�.  $��Details��6k   $��581,107,78,280q�6}    J� RenderTransformOrigin$ 0.542,-0.253&�6�   ��6   �� *" GuestViewModel.DetailRoomCommand+6�   �� 5"   
   $��Date Start
(dd-mm-yyyy)��6   $��10,337,645,36q�6;   �� 5#   
    �� TextWrapping$
 Wrap=�6   $��10,379,645,18q�6�   ��6&   �� *GuestViewModel.DateStart+$ TwoWay=�$ PropertyChanged=�6�   �� 5$   
   $��Date End
(dd-mm-yyyy)��6   $��195,337,460,36q�69   �� 5%   
   $
 Wrap=�6   $��195,379,460,18q�6�   ��6&   �� *GuestViewModel.DateEnd+$ TwoWay=�$ PropertyChanged=�6�   �� 5&   
   $��Search��6   $��364,370,318,10q�6S   ��6"   �� *GuestViewModel.SearchCommand+6S   �� 5'   
   $��Reservations��6   $��581,366,101,10q�6P   ��6(   �� *ReservationsCommand+6P   5(      5)      