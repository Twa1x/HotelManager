   M S B A M L   `   `   `  ����G  CHotelManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HotelManagerHotelManager  5   	   A%clr-namespace:HotelManager.ViewModelsHotelManager.ViewModels  5   	       HotelManager.SignUpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HotelManager     5   	   <
viewmodels%clr-namespace:HotelManager.ViewModels     5   	     � Title$  SignUpWindow��5	   	   $	��450��6   $	��800��6+    � DataContext 5
      -   'HotelManager.ViewModels.SignUpViewModel  5   
   ��5      �� 5   
    �� ImageSource$% /Resources/backgroundSignUp.jpg��6    j� Stretch$
 Fill=�6C   .��5      � .+�5   
   �� $��      USERNAME ��6   $
��Left=�6*   $	��Top=�6E   $��
304,61,0,0q�6]   ���	#FF277B80$	��152��6�   $��33��6�   $��16(�6�   ���	#FFB0B0B06�   �� 5   
   $��      PASSWORD��6   $
��Left=�6)   $	��Top=�6D   $��304,127,0,0q�6\   ���	#FF277B80$	��152��6�   $��33��6�   $��16(�6�   ���	#FFB0B0B06�   G� 5   
   -   5        $��pwdBox��5   �   !   HotelManager.PasswordHelper   Attach . $
��Left=�6�   $	��Top=�6�   $	��152��6�   $��304,165,0,0q�6   $��26��6     Password 6;   �� *SignUpModel.Password+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5   
   $
��Left=�6   $��23��6.    �� TextWrapping$
 Wrap=�6:   $	��Top=�6�   $	��152��6�   $��
304,99,0,0q�6�   ��6O   �� *SignUpModel.Username+$ OneWayToSource=�$ PropertyChanged=�6�   �� 5   
   $��Sign Up��65   $
��Left=�6G   $	��Top=�6b   $��92��6z   $��330,366,0,0q�6�   ���	#FF4F1BFF���	#FFF3992B��6   �� *SignUpCommand+6�   �� 5   
   -   5        $��admCheckBox��5   o   $��Admin��6�   $��256,300,475,73q�6�   	 d� 	IsChecked	 6   �� *SignUpModel.IsAdmin+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5        $��empCheckBox��5   r   $��Employee��6�   $��342,300,362,73q�6�   	 6   �� *SignUpModel.IsEmployee+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5        $��userCheckBox��5   n   $
��User��6�   $��452,300,272,91q�6�   	 6   �� *SignUpModel.IsUser+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��       EMAIL��6   $
��Left=�6'   $	��Top=�6B   $��304,217,0,0q�6Z   ���	#FF277B80$	��152��6�   $��33��6�   $��16(�6�   ���	#FFB0B0B06�   �� 5   
   $
��Left=�6   $��23��6.   $
 Wrap=�6:   $	��Top=�6�   $	��152��6�   $��304,256,0,0q�6�   ��6O   �� *SignUpModel.Email+$ OneWayToSource=�$ PropertyChanged=�6�   5      5      