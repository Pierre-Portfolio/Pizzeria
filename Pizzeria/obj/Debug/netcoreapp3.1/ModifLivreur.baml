   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.ModifLivreur   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  ModifLivreur��5   	   $	��492��6   $	��365��6+    � Icon$ /logoPizza.png��67    � 
ResizeMode$ NoResize=�6M   ��5	      �� 5
   
    �� ImageSource$ /Pizza-Background.jpg��6    j� Stretch$
 None=�69   .��5      � $��0,0,0,23q�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��
0,10,0,-10q�6   .+�5      �� -   5        $��Valider��5      $��25��6'    �� Left$	 104��63   
 �� Top$	 405��6E   $	��126��6V    � Cursor$
 Hand��6b   ���	#FF34B1046�   �� 5      -   5        	 ��Name$	 BoxNom��5      $��22��6&   $ 92��62   $ 49��6C   
 �� TextWrapping$

 Wrap=�6S   $	��150��6g   4  .System.Windows.Automation.AutomationProperties   Name$	 Nom��6s   �� 5      $��20��6   $ 92��6$   $	 103��65   $��Prenom :��6F   $
��Wrap=�6V   $��59��6j   ${�False��6u   $
��Bold"�6�   ���#FFFFFF6�   �� 5      -   5        $	 	BoxPrenom��5      $��22��6)   $ 92��65   $	 123��6F   $

 Wrap=�6W   $	��150��6k   $ Prenom��6w   �� 5      $��20��6   $ 92��6$   $ 29��65   $��Nom :��6E   $
��Wrap=�6R   $��59��6f   ${�False��6q   $
��Bold"�6�   
���   �
�������6�   �� 5      $��20��6   $ 92��6$   $	 168��65   $��
Adresse : ��6F   $
��Wrap=�6X   $��59��6l   ${�False��6w   $
��Bold"�6�   ���#FFFFFF6�   �� 5      -   5        $	 
BoxAdresse��5      $��22��6*   $ 92��66   $	 188��6G   $

 Wrap=�6X   $	��150��6l   $ Adresse��6x   �� 5      $��20��6   $ 92��6$   $	 235��65   $
��Wrap=�6F   $��75��6Z   ${�False��6e   $
��Bold"�6w   ���#FFFFFF�� 6�    � Language$ fr-fr�6�   $�	Telephone��6�   �� 6�   $	� : ��6�   6�   �� 5      -   5        $	 BoxTel��5      $��22��6&   $ 92��62   $	 255��6C   $

 Wrap=�6T   $	��150��6h   $	 Tel��6t   �� 5      $��20��6   $ 92��6$   $	 291��65   $
��Wrap=�6F   $��75��6Z   ${�False��6e   $
��Bold"�6w   ���#FFFFFF�� 6�   $ fr-fr�6�   $�Etat :��6�   6�   �� 5      -   5         ��Name$ ComboBoxEtat��5      $ 92��6-   $	 311��6>   $	��150��6O   �� 5      $��20��6   $ 92��6$   $	 349��65   $
��Wrap=�6F   $��75��6Z   ${�False��6e   $
��Bold"�6w   ���#FFFFFF�� 6�   $ fr-fr�6�   $�
Transport ��6�   �� 6�   $�:��6�   6�   �� 5      -   5        $ ComboBoxTransport��5      $ 92��62   $	 369��6C   $	��150��6T   5      5      5       