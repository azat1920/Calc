   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfClient	WpfClient  5   	       WpfClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:WpfClient     5   	   -   5          � Title$  
MainWindow��5   	   $��373.78��6   $��608.727��6,    � 
ResizeMode$ NoResize=�6<   .��5      � ���	#FF709AA0 � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ tb��5      $��22��6   $��0,303,143.6,0q�6*    �� TextWrapping$
 Wrap=�6A   $	��Top=�6U   $��Right=�6m   $	��413��6�   $��0��6�   ���	#FFD3DEE16�   �� 5   
   -   5         ��Name$ btnSend��5         WpfClient.MyResources   Send#��Z 6"      Triggers#��[  6N   $��0,303,13.6,0q�6p   $	��Top=�6�   $��22��6�   $��Right=�6�   $	��116��6�    �� 	IsDefault . ���	#FFD3DEE16�   �� 5   
   -   5         ��Name$
 List��5      $	��278��6    $��10,10,143.6,0q�6-   $	��Top=�6D   ���	#FFD3DEE16�   �� 5   
   -   5        $ 	btnCancel��5      	   Cancel#��Z	 6B   $��0,267,13.6,0q�6p   $	��Top=�6�   $��21��6�   $��Right=�6�   $	��116��6�   
 �� IsCancel
 . ���	#FFD3DEE1��6$   �� *
ExitProg+6�   �� 5   
   -   5         ��Name$
 tbIp��5      $
��Left=�6`   $��
464,10,0,0q�6{   $
��Wrap=�6�   $	��Top=�6�   $	��116��6�   $��30��6�   ���	#FFD3DEE1��6"   ��    WpfClient.Ip   mess �� Source# Z  �� Mode$ OneWay=�6�   �� 5   
   -   5        $
 Oper��5      $
��Wrap=�6"   $��7,303,0,9.8q�66   $��16(�6K   $��>��6Y   $
��Left=�6e   $��25��6�    �� TextAlignment$ Right=�6�   ���	#FFD3DEE16�   5      5      