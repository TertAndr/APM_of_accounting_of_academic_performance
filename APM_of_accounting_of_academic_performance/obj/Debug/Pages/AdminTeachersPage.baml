   M S B A M L   `   `   `  ����d  `APM_of_accounting_of_academic_performance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:APM_of_accounting_of_academic_performance.Pages/APM_of_accounting_of_academic_performance.Pages  5      G    AAPM_of_accounting_of_academic_performance.Pages.AdminTeachersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:APM_of_accounting_of_academic_performance.Pages     5        N� Title$  AdminTeachersPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   �� -   5         ��Name$ LetterrsStackPanel��5       �� Orientation$ 
Horizontal=�62   5      �� 5   
   $ 
Horizontal=�6   $��0��6.   $��Right=�6;   .+�5      �� -   5        $	��250��5         SmallInventButton#��[  6"   $��0,0,20,0q�6M   .��6   :8Добавить нового преподавателя6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersDataGrid��5   4    �� TextAlignment$ Center=�6   $��1��6K      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y      
IsReadOnly .    AutoGenerateColumns .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Фамилия��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *teacher_fname+6Z     5      $
 Имя��6%    62   �� *teacher_name+6U     5      $
 Отчество��6%    67   �� *teacher_patronomic+6`     5      $
 
Логин��6%    64   �� *Users.user_login+6[     5      $
 Пароль��6%    65   �� *Users.user_password+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5       �� -   5        $��Подробнее��5    %   6Y   5!      5#        5$       5%      �� 5&      .R�5'      �� -   5        $��Удалить��5'   %   6\   5(      5*      5,      5.      5/      