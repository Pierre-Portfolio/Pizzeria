   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  Pizzeria��5   	   $	��600��6   $
��1000��6'    � Icon$ /logoPizza.png��64    � 
ResizeMode$ NoResize=�6J   .��5	      � -   5         �Name$ MainGrid��5	      $��0,0,0,10q�6    � ColumnDefinitions 5   
   �� 5      $	��25* �6   �� 5      $	��25* �6   �� 5      $	��25* �6   �� 5      $	��24* �6   �� 5       � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0��6   $��5��6,   ��5      �� 5       �� ImageSource$ /banner3.jpg��6   .+�5      �� $��
Tittle.png��6   $��60��6(   $��Center=�64   5      �� 5    
   -   5         ��Name$ 
ClientsBtn��5       $��Clients��6%   $��1��67   $��0��6D   
��� ���$��0q�6h   6|   �� 5"   
   -   5        $ CommandesBtn��5"      $��	Commandes��6'   $��1��6;   $��1��6H   
��� ���$��0q�6l   6�   �� 5$   
   -   5        $ StatistiqueBtn��5$      $��Statistiques��6)   $��1��6@   $��2��6M   
��� ���$��0q�6q   6�   �� 5&   
   -   5        $ AdminitrationBtn��5&      $��Administrations��6+   $��1��6E   $��3��6R   
��� ���$��0q�6w   $��2��6�   � 5(   
   $��2��6   $��0��6   $��5��6,   $��	0,0,0,-13q�6@   ��5*      �� 5+      $ /Pizza-Background.jpg��6   .+�5-      �� -   5        $��CanvaConnexion��5-      .+�5.      �� $��500,50,58,50q�6   .+�5/      �� -   5        $��BoxNom��5/       �� Left$ 80��6,   
	 �� Top$		 139��6=   $�� ��6N   
 �� TextWrapping$

 Wrap=�6V   $	��244��6j   $��30��6v   �� 50      $��Nom :��6   $ 80��6,   $		 100��6=   $��84��6N   
�������$��22(�6l   �� 51      $��Mot de passe :��6   $ 80��65   $		 213��6F   $	��162��6W   
�������$��22(�6v   G� 52      -   5        $��PasseWordBox��52   "   $ 80��66   $		 252��6G   $	��244��6X   $��30��6d   �� 53      $��	Connexion��6   $	 119��60   $	 26��6B   $	��166��6R   
�������$��30(�6q   $
��Bold"�6   $��Normal&�6�   �� 54      -	   5        $��	Connexion��54      $	 128��61   $		 351��6C   $��36��6T   $	��148��6`   6l   55      �� 56      $��58,50,500,50q�6   .+�57      �� $%��    Salut à toi 
 jeune commis��6   $ 20��6I   $		 102��6Z   $��60(�6k   $	��184��6y   $	��422��6�   
�������$
��Bold"�6�   58      59      5;      5<      5=      