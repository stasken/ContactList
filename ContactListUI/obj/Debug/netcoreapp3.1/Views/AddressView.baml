   M S B A M L   `   `   `  ����H  DContactListUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ContactListUI.ViewsContactListUI.Views  5      %    ContactListUI.Views.AddressView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ContactListUI.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $	��100��6   $��1��6!   $��1��6.   .��6>   Street6F   �� 5   
   $��1��6>   $��2��6K   ��6   ��  �� Path$ Street� �� Mode$ OneWay=�6]   �� 5    
   $	��100��6   $��2��6!   $��1��6.   .��6>   Number6F   �� 5!   
   $��2��6>   $��2��6K   ��6   �� $ Number�$ OneWay=�6]   �� 5$   
   $	��100��6   $��3��6!   $��1��6.   .��6>   	Extension6I   �� 5%   
   $��3��6A   $��2��6N   ��6   �� $ 	Extension�$ OneWay=�6`   �� 5(   
   $	��100��6   $��4��6!   $��1��6.   .��6>   Postal code6K   �� 5)   
   $��4��6B   $��2��6O   ��6   �� $ 
PostalCode�$ OneWay=�6a   �� 5,   
   $	��100��6   $��5��6!   $��1��6.   .��6>   City6D   �� 5-   
   $��4��6<   $��2��6I   ��6   �� $
 City�$ OneWay=�6[   5.      5/      