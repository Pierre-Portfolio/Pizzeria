   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.addCommis   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  Ajout commis��5   	   $	��450��6   $	��338��6+    � Icon$ /logoPizza.png��67   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��33* �6   �� 5      $
��280* �6   �� 5      $	��25* �6   .+�5   
   �� $��3��6   $
��Left=�6%   $	��434��6@   $��Center=�6M   $	��338��6h   ��5      �� 5       �� ImageSource$ /banner2.jpg��6    j� Stretch$ UniformToFill=�68   .+�5      �� -   5        $��Valider��5      $��25��6'    �� Left$	 106��63   
 �� Top$	 378��6E   $	��126��6V    � Cursor$
 Hand��6b   ���	#FF34B1046�   �� 5      -   5        $��BoxNom��5      $��22��6$   $ 94��60   $ 89��6A    �� TextWrapping$
 Wrap=�6Q   $	��150��6e   4  .System.Windows.Automation.AutomationProperties	   Name$		 Nom��6q   �� 5      $��20��6   $ 94��6$   $	 136��65   $��Prenom :��6F   $
��Wrap=�6V   $��59��6j   ${�False��6u   $
��Bold"�6�   ���#FFFFFF6�   �� 5      -   5        $��	BoxPrenom��5      $��22��6'   $ 94��63   $	 156��6D   $
 Wrap=�6U   $	��150��6i   $	 Prenom��6u   �� 5      $��20��6   $ 94��6$   $ 69��65   $��Nom :��6E   $
��Wrap=�6R   $��59��6f   ${�False��6q   $
��Bold"�6�   
���   �
�������6�   �� 5      $��20��6   $ 94��6$   $	 199��65   $��
Adresse : ��6F   $
��Wrap=�6X   $��59��6l   ${�False��6w   $
��Bold"�6�   ���#FFFFFF6�   �� 5      -   5        $��
BoxAdresse��5      $��22��6(   $ 94��64   $	 219��6E   $
 Wrap=�6V   $	��150��6j   $	 Adresse��6v   �� 5      $��20��6   $ 94��6$   $	 265��65   $
��Wrap=�6F   $��75��6Z   ${�False��6e   $
��Bold"�6w   ���#FFFFFF�� 6�   
 � Language$
 fr-fr�6�   $�	Telephone��6�   �� 6�   $	� : ��6�   6�   �� 5      -   5        $��BoxTel��5      $��22��6$   $ 94��60   $	 285��6A   $
 Wrap=�6R   $	��150��6f   $		 Tel��6r   5      5      5       