   M S B A M L   `   `   `  ����H  DAlertToCareUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AlertToCareUI.ViewModelAlertToCareUI.ViewModel  5      9!clr-namespace:AlertToCareUI.ViewsAlertToCareUI.Views  5      *    $AlertToCareUI.Views.AlertManagerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;	viewModel%clr-namespace:AlertToCareUI.ViewModel     5      3local!clr-namespace:AlertToCareUI.Views     5      
�������.��5
      � $��Center=�6   $��Center=�6(   
�������  � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   �� 5      $
��auto �6   6.   .+�5   
   �� $��Alert Monitor��6   $��18(�6(   $
��Bold"�66   $��5q�6H   $��Center=�6S   $��Center=�6p   $��2��6�   �� 5   
   $��Select ICU - ��6   $��14(�6(   $��1��66   $��0��6C   �� 5   
   $��Select Bed - ��6   $��14(�6(   $��2��66   $��0��6C   �� 5   
   $��Select Alert - ��6   $��14(�6*   $��3��68   $��0��6E   �� 5   
   -   5        $��cmbICU��5      $��1��6M   $��1��6Z   $��5q�6j   $	��100��6v   �� 5   
   -   5        $��cmbBeds��5      $��2��6z   $��1��6�   $��5q�6�   $	��100��6�   ��6N   ��  �� Path$ BedsWithAlerts�6�   �� 5   
   -   5        $��	cmbAlerts��5      $��3��6�   $��1��6�   $��5q�6�   $	��100��6�   ��6R   �� $ AlertOnSelectedBed�6�   �� 5   
   $��4��67   $��0��6D   $��2��6T   $��2��6e   $��5q�6y    �� TextWrapping$
 Wrap=�6�   $	��210��6�   $��50��6�   ��6   �� $ DisplayMessage�6�   �� 5    
   -   5        $��
btnDisable��5    *   $��6��6<   $��0��6I   $��5q�6Y   $��Disable Alarm��6d   $	��100��6|   �� 5!   
   -   5        $��btnUndoDisable��5!   .   $��6��6D   $��1��6Q   $��5q�6a   $
��Undo��6l   $	��100��6{   5#      5$      