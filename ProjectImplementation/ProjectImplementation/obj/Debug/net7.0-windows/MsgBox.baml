   M S B A M L   `   `   `  ����P  LProjectImplementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectImplementationProjectImplementation  5   	   "    ProjectImplementation.MsgBox   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5local#clr-namespace:ProjectImplementation     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�5	   	   
�������$��2q�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��150��5   	   $	��500��6   .��5      �    WindowBackgroundBrush#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ MessageText��5      
�������$
��Bold"�6<   $��Center=�6N   $	��Abc��6k   $��0��6v   $��10,25,10,15q�6�   $
��Wrap=�5      $��16(�6(   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� -   5         ��Name$ OkButton��5      $��OK��6'   $	��100��64   $��5q�6@   6K   �� 5      -   5        $ CancelButton��5      $��Anuluj��6+   $y�	Collapsed=�6<   $	��100��6S   $��5q�6_   6j   5      5      5      