   M S B A M L   `   `   `  ����H  DContactListUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ContactListUI.ViewsContactListUI.Views  5   	   #    ContactListUI.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ContactListUI.Views     5   	   $��18(�5        � WindowStartupLocation$  CenterScreen=�6(    � Title$ 	ShellView��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6@   $��1��6M   ��6   ��  �� Path$ FullName� �� Mode$ OneWay=�6_   �� 5!   
   -   5         ��Name$ 	FirstName��5!   !   $	��100��6   $��2��64   $��1��6A   6S   �� 5"   
   -   5        $ LastName��5"   !   $	��100��6   $��2��63   $��2��6@   6R   �� 5%   
   -   5         ��Name$ Contacts��5%   0   $��3��6   $��1��6     �� DisplayMemberPath$ 	FirstName��6�   	 �� SelectedItem	 6B   �� $ SelectedContact�$ OneWayToSource=�6�   �� 5&   
   -   5        
 ��Name$
 SelectedContact_LastName��5&   1   $��3��6   $��2��6!   61   �� 5)   
   -   5         ��Name$ GetContacts��5)      $��4��6'   $��2��64   .��6D   Get contacts6R   �� 5*   
   -   5        $ 	ClearText��5*      $��4��6%   $��1��62   .��6B   Clear6I   �� 5-   
   -   5        $ LoadPageOne��5-      $��5��6'   $��1��64   .��6D   Show Address6R   �� 5.   
   -   5        $ LoadPageTwo��5.      $��5��6'   $��2��64   .��6D   Show Phonenumbers6W   �� 51   
   -	   5         ��Name$ 
ActiveItem��51   J   $��6��6   $��1��6&   $��5��66   6J   52      54      