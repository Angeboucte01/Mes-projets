   M S B A M L   `   `   `  ����D  @WPF_BD_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPF_BD_10	WPF_BD_10  5   	       WPF_BD_10.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPF_BD_10     5   	     � Title$  Gestions des Etudiants��5   	   $	��450��6(   $	��700��65   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Nom : ��6   $��0��6!   $��0��6.   $��25(�6>   �� 5   
   $��
Prénom : ��6   $��1��6$   $��0��61   $��25(�6A   �� 5   
   $��	Groupe : ��6   $��2��6$   $��0��61   $��25(�6A   �� 5   
   $��Liste des étudiants : ��6   $��3��61   $��0��6>   $��2��6N   $��25(�6b   �� 5    
   -   5         ��Name$ txtNom��5       $��0��6"   $��1��6/   $��0 5 0 5q�6?   �� 5!   
   -   5        $ 	txtPrenom��5!      $��1��6%   $��1��62   $��0 5 0 5q�6B   �� 5%   
   -   5        $ txtTrait��5%      $��3��6$   $��2��61   $��0 5 0 5q�6A   $��19(�6R   5&      �� 5'   
   -   5         ��Name$ lblHint��5'      $��ID à supprimer��6!   $��3��6:   $��2��6G   $��0 5 0 5q�6W   
�������$��19(�5(   '    J� IsHitTestVisible .  65   �� 5.   
   -   5         ��Name$ 	cbxGroupe��5.      $��2��6&   $��1��63   $��0 5 0 5q�6C   5/      &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ dgListe��50      $��4��6$   $��0��61   $��4��6A   $��4��51      $��5 5 5 5q�6$      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 150 6a   �� 55   
   -   5        	 ��Name$	 	btnInsert��55      $��Ajouter��6$   $��3��66   $��0��6F   $��5 5 5 5q�56      $��21(�6"   60   �� 57   
   -   5        $	 	btnUpdate��57      $��Modifier��6$   $��3��67   $��1��6G   $��5 5 5 5q�58      $��21(�6"   60   �� 59   
   -	   5        $	 	btnDelete��59      $��	Supprimer��6$   $��3��68   $��2��6H   $��5 5 5 5q�5:      $��21(�6"   60   5;      5<      