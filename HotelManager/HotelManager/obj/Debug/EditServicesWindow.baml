   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager  5   	   A%clr-namespace:HotelManager.ViewModelsHotelManager.ViewModels  5   	   %    HotelManager.EditServicesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HotelManager     5   	   <
viewmodels%clr-namespace:HotelManager.ViewModels     5   	     � Title$  EditServicesWindow��5	   	   $	��450��6$   $	��800��61    � DataContext 5
      /   )HotelManager.ViewModels.ServicesViewModel  5   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5      $��Center=�6%   $	��270��6B   $��0,49,0,0q�6O   $	��Top=�6a   $	��198��6y      AutoGenerateColumns .  ��6�   �� *
Services+ �� SelectedItem 6�   �� *CurrentService+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$
 Name��67      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+	 �� Mode$	 OneWay=�
 �� UpdateSourceTrigger$
 Default=�6�     5       . $ Price��67   $	 100 6�    6F   �� *Price+$	 OneWay=�$
 Default=�6�      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      -   5        5      5      �� 5   
   -   5        $
��edit��5      {�.  $��Edit Selected��6O   $��262,350,424,34q�6g   ��6   �� *EditCommand+6g   �� 5   
   -   5        $��delete��5      {�.  $��Delete Selected��6T   $��421,350,265,34q�6n   ��6   �� *DeleteCommand+6n   5      5       