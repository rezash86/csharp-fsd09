   M S B A M L   `   `   `  ����A  =TodoDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TodoDbTodoDb  5   	       TodoDb.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:TodoDb     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��650��6)    � 
ResizeMode$ NoResize=�65   .��5	      � .+�5
   
   �� -   5        $��lvTodos��5
   ?   $��10,10, 250, 100q�6N    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 65��61    �� DisplayMemberBinding 6<   �� *Id+6b   �� 5      $
��Task��6%   $ 80��63    6>   �� *Task+6f   �� 5      $��
Difficulty��6%   $ 80��69    6D   �� *
Difficulty+6r   �� 5      $��DueDate��6%   $ 80��66    6A   �� *	DueDate+ �� StringFormat$ d��6|   �� 5      $��Status��6%   $ 80��65    6@   �� *Status+6j   5      5      �� 5   
   $
��Task��6   $
��Left=�6   $	��Top=�6:   $��420,15, 0,0q�6R   6i   �� 5   
   -   5         ��Name$ tbTask��5      $
��Left=�6"   $	��Top=�6=   $��
500,21,0,0q�6U   $	��130��6i   6w   �� 5   
   $��
Difficulty��6   $
��Left=�6%   $	��Top=�6@   $��
420,60,0,0q�6X   6n   �� 5   
   -   5        $��sliderDifficulty��5      $
��Left=�6)   $	��Top=�6D   $��
500,65,0,0q�6\   $	��130��6p    � Value$ 2Q�6|    � SmallChange$ 1Q�6�   	 �� TickPlacement$	 BottomRight=�6�   
 �� TickFrequency$
 1Q�6�    � Minimum$ 1Q�6�    � Maximum$ 5Q�6�    �� IsSnapToTickEnabled . 6�   �� 5   
   $
��Left=�6r   $	��Top=�6�   $��
476,61,0,0q�6�   ��6   ��  �� ElementName$ sliderDifficulty�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��DueDate��6   $
��Left=�6"   $	��Top=�6=   $��421,110,0,0q�6U   6l   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��	dpDueDate��5      $
��Left=�6&   $	��Top=�6A   $��500,110,0,0q�6Y   6p   �� 5   
   $��Status��6   $
��Left=�6!   $	��Top=�6<   $��420,158,0,0q�6T   6k   �� 5   
   -   5        $��comboStatus��5      $
��Left=�6&   $	��Top=�6A   $��500,158,0,0q�6Y   $	��130��6n   6|   �� 5   
   -   5         ��Name$ btnAdd��5      $	��Add��6!   $��50��6/   $
��Left=�6:   $	��Top=�6U   $��428,211,0,0q�6m   6�   �� 5   
   -   5        $ 	btnDelete��5      {�.  $��Delete��66   $��50��6G   $
��Left=�6R   $	��Top=�6m   $��500,211,0,0q�6�   6�   �� 5    
   -   5        $ 	btnUpdate��5       {�.  $��update��66   $��50��6G   $
��Left=�6R   $	��Top=�6m   $��580,211,0,0q�6�   6�   5#      5$      