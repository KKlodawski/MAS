   M S B A M L   `   `   `  ����P  LProjectImplementation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjectImplementationProjectImplementation  5   	   -    'ProjectImplementation.GameListAddWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   5local#clr-namespace:ProjectImplementation     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$+ %GamesCompanyAssistant - przypisz grę��5	   	   $	��450��66   $	��400��6C   .��5
      �    WindowBackgroundBrush#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��   TextBoxStyle#��[ 6   $��
Nazwa gry:��6:   $��10q�6L   �� 5   
   -   5         ��Name$ GamesListBox��5       �� SelectionMode$ Single=�6(    �� DisplayMemberPath$ Tytul��6?   $��10q�6Y   $��1��6e   6r   �� 5   
   -   5        $��
Potwierdź��5      $��10q�6%   $��2��61   $��Right=�6>   6Z   5      5      