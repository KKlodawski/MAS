   M S B A M L   `   `   `  ����P  LProjectImplementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectImplementationProjectImplementation  5   	   -    'ProjectImplementation.TaskAddFormWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5local#clr-namespace:ProjectImplementation     5   	     � Title$+  %GamesCompanyAssistant - dodaj zadanie��5   	   $	��450��67   $	��620��6D   .��5	      �    WindowBackgroundBrush#��[  6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��   TextBoxStyle#��[ 6   $��Nazwa zadania��6:   $��0��6O   $��10q�6\   $��Center=�6h   �� 5   
   #��[ 6   $��Nazwa zadania:��6:   $��1��6P   $��10q�6]   $��Center=�6i   �� 5   
   -   5         ��Name$ TaskNameTextBox��5      $��2��6+   $��10q�68   �� 5   
   #��[ 6   $��Opis:��6:   $��3��6G   $��10q�6T   $	��Top=�6`   �� 5   
   -   5        $ DescriptionTextBox��5      $��4��6.   $��10q�6;    �� TextWrapping$
 Wrap=�6G    �� AcceptsReturn$
 True��6[   $��Visible=�6p   � 5   
   $��5��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5       $��* �6#   .+�5#      �� #��[ 6   $��Termin:��6>   $��0��6M   $��10q�6]   $��Center=�6i   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ DeadlineDatePicker��5$   S     DatePickerStyle#��[ 6   $��1��6C   $��10q�6o   $	��500��6{   $��Right=�6�   5%      � 5&   
   $��6��6    5'      �� 5(      $
��Auto �6#   �� 5)      $��* �6#   .+�5,      �� #��[ 6   $��Status:��6>   $��0��6M   $��0��6Z   $��10q�6j   $��Center=�6v   �� 5-      -   5         ��Name$ StatusComboBox��5-      $��1��6/   $��10q�6?    �� SelectedIndex$ 0��6K   $��Right=�6]   $	��500��6y   .@�5/      �� $��wtrakcie��6   �� 50      $��zakończone��6   �� 51      $��	przerwane��6   52      53      �� 55   
   -   5        $��
Zatwierdź��55      $��7��6%   $��10q�62   $��Right=�6>   6Z   57      58      