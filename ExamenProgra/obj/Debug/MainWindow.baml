   M S B A M L   `   `   `  ����  ExamenProgra    ExamenProgra.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ExamenProgra��5   	   $	��450��6   $
��1200��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6   $��Right=�6"    �� Orientation$ 
Horizontal=�6>   .+�5      �� -   5         ��Name$ 
BtnAgregar��5      $��Agregar��6)   $��5q�6;   6F   �� 5      -   5        $ BtnEliminar��5      $��Eliminar��6*   $��5q�6=   6H   �� 5      -   5        $ BtnActualizar��5      $��
Actualizar��6,   $��5q�6A   6L   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Nombre:��6   $��Center=�6'   $��5q�6B   �� 5      -   5         ��Name$ 	TxtNombre��5   -   $	��200��6   $��5q�6"   6-   �� 5      $��Descripción:��6   $��Center=�6,   $��5q�6G   �� 5      -   5        $ TxtDescripcion��5   -   $	��200��6   $��5q�6"   6-   �� 5      $��Precio:��6   $��Center=�6'   $��5q�6B   �� 5      -   5        $ 	TxtPrecio��5   -   $	��200��6   $��5q�6"   6-   �� 5      $��Disponible:��6   $��Center=�6+   $��5q�6F   �� 5      -   5         ��Name$ ChkDisponible��5   =   $��Center=�6   $��5q�62   6=   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductosDataGrid��5   G   $��3��6   $��5q�6       AutoGenerateColumns .     SelectionMode$ Single=�6b   	   SelectionUnit$	 FullRow=�6y   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5!      $ Nombre��6%    65   �� *Nombre+  5"      $ Descripción��6%    6:   �� *Descripcion+  5#      $ Precio��6%    65   �� *Precio+4  .System.Windows.Controls.DataGridCheckBoxColumn  5$      $ 
Disponible��6)    6=   �� *
Disponible+5&      5'      5(      