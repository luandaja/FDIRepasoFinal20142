   M S B A M L   `   `   `  ����  UI    UI.PEmpleado   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Gestión de Empleado��5      .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��170* �6   �� 5      $
��170* �6   �� 5      $
��170* �6   �� 5      $
��170* �6    � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��75* �6   .+�5   
   �� $��0��6   $��1��6    $��Nombre:��6-   $��Right=�6?   $��Center=�6[   6x   �� 5   
   $��2��6   $��1��6    $��	Apellido:��6-   $��Right=�6A   $��Center=�6]   6z   �� 5   
   $��0��6   $��2��6    $��Fecha de Nacimiento:��6-   $��Right=�6L   $��Center=�6h   6�   �� 5   
   $��2��6   $��2��6    $
��DNI:��6-   $��Right=�6<   $��Center=�6X   6u   �� 5   
   -   5         ��Name$ 
txt_Nombre��5      $��1��6&   $��1��66   $��5q�6D   6R   �� 5    
   -   5        $ txt_Apellido��5       $��3��6(   $��1��68   $��5q�6F   6T   �� 5!   
   -   5        $ txt_DNI��5!      $��3��6#   $��2��63   $��5q�6A   6O   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ 	dtp_Fecha��5#      $��1��6(   $��2��68   $��5q�6F   6S   �� 5%   
   -   5         ��Name$ btn_Agregar��5%      $��3��6&   $��4��66   $��7q�6C   $��Agregar��6N   6|   �� 5&   
   -   5        $ btn_Modificar��5&      $��2��6(   $��4��68   $��7q�6E   $��	Modificar��6P   6�   �� 5'   
   -   5        $ btn_Eliminar��5'      $��1��6'   $��4��67   $��7q�6D   $��Eliminar��6O   6   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ 	dtg_Datos��5)      $��0��6&   $��4��66   $��5��6J   $��10q�6W      AutoGenerateColumns . 6�   5*      5+      