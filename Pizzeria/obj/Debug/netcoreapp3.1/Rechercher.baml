   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.Rechercher   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  
Rechercher��5   	   $	��450��6   $��330         ��6)    � Icon$ /logoPizza.png��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��33* �6   �� 5      $
��305* �6   .+�5   
   �� $��2��6   $
��Left=�6%   $	��434��6@   $��Center=�6M   $	��330��6h   ��5      �� 5       �� ImageSource$ /banner2.jpg��6    j� Stretch$ UniformToFill=�68   .+�5      �� -   5        $��
Rechercher��5      $��25��6*    �� Left$	 106��66   
 �� Top$	 111��6H   $	��126��6Y    � Cursor$
 Hand��6e   ���	#FF34B1046�   �� 5      $��20��6   $ 94��6$   $ 38��65   $
��Wrap=�6E   $��75��6Y   ${�False��6d   $
��Bold"�6v   ���#FFFFFF�� 6�    � Language$ fr-fr�6�   $�	Telephone��6�   �� 6�   $	� : ��6�   6�   �� 5      -   5        $��BoxTel��5      $��22��6$   $ 94��60   $ 58��6A   	 �� TextWrapping$
	 Wrap=�6Q   $	��150��6e   4  .System.Windows.Automation.AutomationProperties
   Name$	
 Tel��6q   �� 5      -   5        $��CanvaClient��5      $	��240��6(   $	��214��65   $ 58��6A   $	 171��6R   $y�Hidden=�6c   .+�5      �� -   5        $��RectText��5      $	��240��6,   
���   �$	��214��6H   
�������$y�Visible=�6a   �� 5      -   5        $��LabelNom��5      $	��Nom��6(   $ 11��66   $ 19��6G   $	��190��6W   �� 5      -   5        $��LabelPrenom��5      $��Prenom��6+   $ 11��6<   $ 55��6M   $	��190��6]   �� 5      -   5        $��LabelTel��5      $	��Tel��6(   $ 11��66   $ 91��6G   $	��190��6W   �� 5      -   5        $��LabelAdresse��5      $��Adresse��6,   $ 11��6>   $	 117��6O   $	��190��6`   $��80��6l   �� 5      -	   5        $��BtnCommande��5      $��	Commander��6,   $ 51��6@   $	 202��6Q   $	��112��6b   6n   5      5      5       5!      