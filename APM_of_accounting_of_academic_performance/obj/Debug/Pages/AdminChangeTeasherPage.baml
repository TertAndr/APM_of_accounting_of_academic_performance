   M S B A M L   `   `   `  ����d  `APM_of_accounting_of_academic_performance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:APM_of_accounting_of_academic_performance.Pages/APM_of_accounting_of_academic_performance.Pages  5      L    FAPM_of_accounting_of_academic_performance.Pages.AdminChangeTeasherPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:APM_of_accounting_of_academic_performance.Pages     5        N� Title$  AdminChangeTeasherPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��	30 10 0 0q�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��
0 40,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   Фамилия:6l   �� 5      -   5         ��Name$ TeasherFamilyTextBox��5      $��30��68   $	��240��6D   $��15,0,0,0q�6P   $��Center=�6b   $��Center=�6}   $��20(�6�   .��6�   Анатольев6�   5      �� 5      $ 
Horizontal=�6   $��
0 10,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   $��0 0 40 0q�6b   	Имя:6z   �� 5      -   5        $ TeasherNameTextBox��5      $��30��66   $	��250��6B   $��15,0,0,0q�6N   $��Center=�6`   $��Center=�6{   $��20(�6�   .��6�   Анатолий6�   5      �� 5      $ 
Horizontal=�6   $��
0 10,20,20q�62   .+�5      �� $��Center=�6   $��Center=�67   $��20(�6T   Отчество:6m   �� 5      -   5        $ TeasherPatronomicTextBox��5      $��30��6<   $	��250��6H   $��5,0,0,0q�6T   $��Center=�6e   $��Center=�6�   $��20(�6�   .��6�   Анатольевич6�   5      �� 5       $
��Left=�6   $ 
Horizontal=�64   $��
0 10,20,20q�6M   .+�5!      �� $��Center=�6   $
��Left=�67   $��20(�6R   Логин:6h   �� 5"      -   5        $ TeasherLoginTextBox��5"      $��30��67   $	��250��6C   $��25,0,0,0q�6O   $��Center=�6a   $��Center=�6|   $��20(�6�   .��6�   Анатольевич6�   5#      �� 5$      $
��Left=�6   $ 
Horizontal=�64   $��
0 10,20,20q�6M   .+�5%      �� $��Center=�6   $
��Left=�67   $��20(�6R   Пароль:6i   �� 5&      -   5        $ TeasherPasswordTextBox��5&      $��30��6:   $	��250��6F   $��15,0,0,0q�6R   $��Center=�6d   $��Center=�6   $��20(�6�   .��6�   Анатольевич6�   5'      �� 5(      .+�5)      ��    DeffTextBlock#��[  6   Выбранная роль6T   �� 5*      -   5         ��Name$ RoleRegistrComboBox��5*      ��68   �� *BigComboBox+6Y   5+      5/      �� 50   
   $��1��6   $��0 20 0 0q�6%   .+�52      �� $	��Top=�6   $��Center=�60   $��20(�6M   $��0 0 0 0q�6[   Фотография6x   ]� 53      $��	0 10 0 10q�6   .+�54      �� -   5         ��Name$ 
PhotoImage��54      $��/Resources/po-photo.jpg��6,   $	��Top=�6M   $��Center=�6e   $	��240��6�   $	��260��6�   55      �� 56      $ 
Horizontal=�6   .+�57      �� -   5        $ PhotoPathTextBox��57      {�.    
DefTextBox#��[ 58   0   $	��250��6T   $��4q�59      64   �� 5:      -	   5         ��Name$ SearchPhotoButton��5:        SmallButton#��[ 5;      .��6b   Обзор...6l   5<      5=      �� 5>   
   -
   5        #��[ 5>      $��1��66   $��Bottom=�6G   $��Right=�6b   $��	0 0 20 20q�6~   .��6�   Сохранить6�   5?      5@      