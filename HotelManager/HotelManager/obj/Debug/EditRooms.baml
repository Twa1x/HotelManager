   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HotelManager.ViewModelsHotelManager.ViewModels  5          HotelManager.EditRooms   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <
viewmodels%clr-namespace:HotelManager.ViewModels     5        � Title$  	EditRooms��5   	   $	��450��6   $	��800��6(   .��5      � .+�5   
   �� $*��$Type of room
(Single/Double/Triple)��6   $
��Left=�6G   $	��Top=�6b   $��	30,72,0,0q�6z   ���	#FF277B80$	��178��6�   $��55��6�   $��16(�6�   ���	#FFB0B0B06�   �� 5   
   $
��Left=�6   $��23��6.    �� TextWrapping$
 Wrap=�6:   $	��Top=�6�   $	��178��6�   $��
30,132,0,0q�6�   ��6O   �� *TempRoom.Type+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Price��6   $
��Left=�6    $	��Top=�6;   $��
30,161,0,0q�6S   ���	#FF277B80$	��178��6~   $��33��6�   $��16(�6�   ���	#FFB0B0B06�   �� 5   
   $
��Left=�6   $��23��6.   $
 Wrap=�6:   $��Center=�6�   $	��178��6�   $��30,0,0,0q�6�   ��6O   �� *TempRoom.Price+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Update��6   $��63,333,625,27q�6#   ��6:   �� *UpdateCommand+�� 5   
   $��Select Image 1��6    J� RenderTransformOrigin$ 0.5,0.5&�6R   $��262,209,426,160q�6r   ��6*   �� *SelectImage1Command+z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.187Q�6&   T� 5      5      5      �� 5   
   $��Select Image 2��6   $ 0.5,0.5&�6R   $��401,210,287,161q�6r   ��6*   �� *SelectImage2Command+z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.056Q�6$   �� 5       $ 0.187Q�6&   T� 5!       T� X$ 0.021Q�6)   5"      5$      �� 5%   
   $��Select Image 3��6   $ 0.5,0.5&�6S   $��537,210,151,162q�6s   ��6+   �� *SelectImage3Command+z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*      $ 0.187Q�6&   T� 5+      5,      5.      �� 5/   
   $��Select Images��6   $
��Left=�6(   $	��Top=�6C   $��385,144,0,0q�6[   ���	#FF277B80$	��152��6�   $��34��6�   $��16(�6�   ���	#FFB0B0B06�   �� 50   
   $	��100��6f   $	��100��6s   $��264,297,436,37q�6   ��6   �� *TempRoom.Image1+$ TwoWay=�$ PropertyChanged=�6   �� 51   
   $	��100��6e   $	��100��6r   $��411,297,289,37q�6~   ��6   �� *TempRoom.Image2+$ TwoWay=�$ PropertyChanged=�6~   �� 52   
   $	��100��6e   $	��100��6r   $��550,297,150,37q�6~   ��6   �� *TempRoom.Image3+$ TwoWay=�$ PropertyChanged=�6~   54      55      