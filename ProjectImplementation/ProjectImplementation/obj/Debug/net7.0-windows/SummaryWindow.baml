   M S B A M L   `   `   `  ����P  LProjectImplementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectImplementationProjectImplementation  5   	   )    #ProjectImplementation.SummaryWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5local#clr-namespace:ProjectImplementation     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$* $GamesCompanyAssistant - Podsumowanie��5	   	   $	��600��66   $	��520��6C   .��5
      �    WindowBackgroundBrush#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��   TextBoxStyle#��[ 6   $��0��6:   $��Podsumowanie��6G   $��10q�6[   $��Center=�6g   $
��Bold"�6�   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� #��[ 6   $��Nazwa grupy:��6>   $��10q�6R   $��Center=�6^   �� 5      -   5         ��Name$ TeamNameTextBox��5      $��1��6/   $��10q�6?   $	��350��6K   $��Right=�6W    �� 
IsReadOnly$
 True��6s   5       � 5"   
   $��2��6    5#      �� 5$      $
��Auto �6#   �� 5%      $��* �6#   .+�5(      �� #��[ 6   $��Przypisana gra:��6>   $��10q�6U   $
��Left=�6a   $��Center=�6|   �� 5)      -   5        $ GameNameTextBox��5)      $��1��6/   $��10q�6?   $	��350��6K   $��Right=�6W   $
 True��6s   5*      �� 5,   
   #��[ 6   $��3��6:   $��Pracownicy:��6G   $��10q�6Z   $
��Bold"�6f   �� 5-   
   -   5         ��Name$ EmployeeListBox��5-      $��4��6+   $��10q�68    �� SelectionMode$ Single=�6D   ��5.      �� 5/      .R�50      ��  �� Orientation$ 
Horizontal=�6!   .+�51      �� $
��3, 0q�6:   ��6$   �� *Imie+6:   �� 52      ��6$   �� *
Nazwisko+53      54      56      �� 58   
   #��[ 6   $��Zadania:��6:   $��5��6J   $��10q�6W   $
��Bold"�6c   �� 59   
   -   5        $ TaskListBox��59      $��6��6'   $��10q�64   	 �� DisplayMemberPath$	 NazwaZadania��6@   $ Single=�6a   �� 5;   
   $��7��6   $��Right=�6"   $ 
Horizontal=�6>   .+�5<      �� -   5        
 ��Name$
 AssignGameButton��5<      $��Przypisz grę��6/   $��10q�6F   $��Right=�6R   6n   �� 5=      -   5        $��Dodaj zadanie��5=      $��10q�6-   $��Right=�69   6U   �� 5>      -   5        $��
Zatwierdź��5>      $��10q�6)   65   5?      5@      5A      