   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfClient	WpfClient  5   	   !    WpfClient.StartDialogWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:WpfClient     5   	     � Title$-  'Свойства подключения��5   	   $��153.733��6&   $��317.069��67    � 
ResizeMode$ NoResize=�5   /    � ShowInTaskbar .   � Topmost .  � WindowStartupLocation$ CenterScreen=�6j   .��5      � $��0,0,-0.2,-0.2q�6   ���	#FF709AA0 � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� $��0,10,176.4,0q�6   $
��Wrap=�6*      WpfClient.MyResources	   Ip#��Z 6>   $	��Top=�6e   $��15��6}   $��Right=�6�   $	��109��6�    �� TextAlignment$ Right=�6�   �� 5   
   $
��Wrap=�6   	   Port#��Z	 6(   $��0,58,160.4,0q�6Q   $��15��6g   $	��Top=�6s   $	��125��6�   $��Right=�6�   $ Right=�6�   �� 5   
   -   5        
 ��Name$

 tbIp��5   #   $��	127.0.0.1��6   $��23��61   $��0,30,160.4,0q�6=    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $��Right=�6�   $	��125��6�   �� 5   
   -   5        $
 tbPort��5      $��11000��6   $��23��6/   $��0,78,160.4,0q�6;   $
 Wrap=�6Q   $	��Top=�6e   $��Right=�6�   $	��125��6�   �� 5   
   -   5         ��Name$ 
btnConnect��5         Connect#��Z 6%   $��0,30,19.4,0q�6T   $��Right=�6~   $	��125��6�   $��23��6�   $	��Top=�6�    �� 	IsDefault . ���	#FFD3DEE16�   �� 5   
   -   5        $ 	btnCancel��5         Cancel#��Z 6$   $��0,78,19.4,0q�6R   $��Right=�6~   $	��125��6�   $��22��6�   $	��Top=�6�    �� IsCancel . ���	#FFD3DEE16�   5      5      