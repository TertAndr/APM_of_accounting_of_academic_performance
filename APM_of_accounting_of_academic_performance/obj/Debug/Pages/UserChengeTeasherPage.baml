   M S B A M L   `   `   `  ����d  `APM_of_accounting_of_academic_performance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:APM_of_accounting_of_academic_performance.Pages/APM_of_accounting_of_academic_performance.Pages  5      K    EAPM_of_accounting_of_academic_performance.Pages.UserChengeTeasherPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:APM_of_accounting_of_academic_performance.Pages     5        N� Title$  UserChengeTeasherPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��	30 40 0 0q�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��
0 20,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   Фамилия:6l   �� 5      -   5         ��Name$ Family_Textbox��5      $��30��62   $	��240��6>   $��15,0,0,0q�6J   $��Center=�6\   $��Center=�6w   $��20(�6�   6�   5      �� 5      $ 
Horizontal=�6   $��
0 20,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   $��0 0 40 0q�6b   	Имя:6z   �� 5      -   5        $ Namey_Textbox��5      $��30��61   $	��250��6=   $��15,0,0,0q�6I   $��Center=�6[   $��Center=�6v   $��20(�6�   6�   5      �� 5      $ 
Horizontal=�6   $��
0 20,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   Отчество:6m   �� 5      -   5        $ Patronomic_Textbox��5      $��30��66   $	��250��6B   $��5,0,0,0q�6N   $��Center=�6_   $��Center=�6z   $��20(�6�   6�   5      �� 5      $
��Left=�6   $ 
Horizontal=�64   $��10q�6M   .+�5       �� $��Center=�6   $
��Left=�67   $��20(�6R   Логин:6h   �� 5!      -   5        $ Login_Textbox��5!      $��30��61   $	��250��6=   $��25,0,0,0q�6I   $��Center=�6[   $��Center=�6v   $��20(�6�   6�   5"      �� 5#      $
��Left=�6   $ 
Horizontal=�64   $��10q�6M   .+�5$      �� $��Center=�6   $
��Left=�67   $��20(�6R   Пароль:6i   �� 5%      -   5        $ Password_Textbox��5%      $��30��64   $	��250��6@   $��15,0,0,0q�6L   $��Center=�6^   $��Center=�6y   $��20(�6�   6�   5&      5(      �� 5)   
   $��1��6   $��0 20 0 0q�6%   .+�5+      �� $	��Top=�6   $��Center=�60   $��20(�6M   $��0 0 0 0q�6[   Фотография6x   ]� 5,      $��	0 10 0 10q�6   .+�5-      �� -   5         ��Name$ 
PhotoImage��5-      $��/Resources/po-photo.jpg��6,   $	��Top=�6M   $��Center=�6e   $	��240��6�   $	��260��6�   5.      �� 5/      $ Horizontal =�6   $��5q�63   .+�51      �� -   5        $ PhotoPathTextBox��51      {�.     
DefTextBox#��[  52   0   $	��230��6T   $��4q�53      64   �� 55      -   5         ��Name$ SearchPhotoButton��55        SmallButton#��[ 56      .��6c   Обзор...6m   57      58      �� 59   
   -	   5        #��[ 59      $��1��66   $��Bottom=�6G   $��Right=�6b   $��	0 0 20 20q�6~   .��6�   Изменить6�   5:      5;      