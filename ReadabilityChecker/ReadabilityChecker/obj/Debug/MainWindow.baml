   M S B A M L   `   `   `  ����M  IReadabilityChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ReadabilityCheckerReadabilityChecker  5   	   #    ReadabilityChecker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ReadabilityChecker     5   	     � Title$  Readability Checker��5   	   $	��945��6%   $
��1200��62   $��16(�6?   ���	#FF8F989C��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color# � ��6    � Offset$ 1Q�6m   � 5      $ White��6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��224* �6   �� 5      $	��91* �6   �� 5      $
��880* �6   .+�5   
   �� -   5         ��Name$ txtMain��5      $
��Left=�6#   $	��738��6>   $��
10,110,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��836��6�   $��15q�6�    �� AcceptsReturn . 	 �� 
AcceptsTab	 . $
��18px(�6�   $��2��6�   �� 5   
   $
��Left=�6   $��78��6/   
���   �$	��Top=�6J   $
��1195��6b   $��3��6o   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ 	#FF40648F��6#   $ 0Q�65   � 5      $ 	#FF5C84B5��6#   $ 1Q�65   5      5      �� 5   
   -   5        
 ��Name$
 btnCheckReadability��5      $��Check Readability��6.   $
��Left=�6J   $��	44,17,0,0q�6e   $	��Top=�6x   $	��229��6�   $��42��6�   $��2��6�   ��5       �� 5!       �� Color# � ��6"   5#      �� 5$   
   -   5         ��Name$ lblWords��5$      $��Words:��6"   $
��Left=�63   $��
44,308,0,0q�6N   $	��Top=�6b   $��88��6z   �� 5%   
   -   5        $ lblWordCount��5%      $�� ��6&   $
��Left=�61   $��218,308,0,0q�6L   $	��Top=�6a   $��80��6y   $��2��6�   �� 5&   
   -   5        $ lblSyllables��5&      $��
Syllables:��6&   $
��Left=�6;   $��
44,360,0,0q�6V   $	��Top=�6j   $	��162��6�   �� 5'   
   -   5        $ lblSyllableCount��5'      $�� ��6*   $
��Left=�65   $��218,360,0,0q�6P   $	��Top=�6e   $��80��6}   $��2��6�   �� 5(   
   -   5        $ lblSentences��5(      $��
Sentences:��6&   $
��Left=�6;   $��
44,334,0,0q�6V   $	��Top=�6j   $	��124��6�   �� 5)   
   -   5        $ lblSentenceCount��5)      $�� ��6*   $
��Left=�65   $��218,334,0,0q�6P   $	��Top=�6e   $��80��6}   $��2��6�   �� 5*   
   -	   5        $ lblSyllablesPerWord��5*      $��Syllables Per Word:��6-   $
��Left=�6K   $��
44,386,0,0q�6f   $	��Top=�6z   $	��162��6�   �� 5+   
   -
   5        $ lblSyllablesPerWordCount��5+      $�� ��62   $
��Left=�6=   $��218,386,0,0q�6X   $	��Top=�6m   $��80��6�   $��2��6�   �� 5,   
   -   5        $ lblWordsPerSentence��5,      $��Words Per Sentence:��6-   $
��Left=�6K   $��
44,412,0,0q�6f   $	��Top=�6z   $	��162��6�   �� 5-   
   -   5        $ lblWordsPerSentenceCount��5-      $�� ��62   $
��Left=�6=   $��218,412,0,0q�6X   $	��Top=�6m   $��80��6�   $��2��6�   �� 5.   
   -   5        $ 
lblDetails��5.      $��Details��6$   $
��Left=�66   $��
44,274,0,0q�6Q   $	��Top=�6e   $��24(�6}   $
��Bold"�6�   �� 5/   
   -   5        $ 
lblFKGrade��5/      $��Flesch-Kincaid Grade:��6$   $
��Left=�6D   $��
44,184,0,0q�6_   $	��Top=�6s   $	��162��6�   �� 50   
   -   5        $ lblFKGradeNumber��50      $�� ��6*   $
��Left=�65   $��218,184,0,0q�6P   $	��Top=�6e   $��80��6}   $��2��6�   �� 51   
   -   5        $ 
lblFKScore��51      $��Flesch-Kincaid Score:��6$   $
��Left=�6D   $��
44,210,0,0q�6_   $	��Top=�6s   $	��162��6�   �� 52   
   -   5        $ lblFKScoreNumber��52      $�� ��6*   $
��Left=�65   $��218,210,0,0q�6P   $	��Top=�6e   $��80��6}   $��2��6�   �� 53   
   -   5        $ lblScoreAndAnalysis��53      $��Score and Analysis��6-   $
��Left=�6J   $��
44,113,0,0q�6e   $	��Top=�6y   $��24(�6�   $
��Bold"�6�   $��2��6�   $	��230��6�   � 54   
   -   5         �Name$ meterFKScore��54      $
��Left=�6,   $��20��6G   $��
44,160,0,0q�6S   $	��Top=�6g   $	��230��6   $��2��6�   ���	#FF72FFA56�   �� 55   
   -   5        $ 	lblStatus��55      $��Status��6#   $
��Left=�64   $��
44,478,0,0q�6O   $	��Top=�6c   $��24(�6{   $
��Bold"�6�   �� 56   
   -   5        $ lblStatusDetails��56      $��Ready to scan��6*   $
��Left=�6B   $��
44,512,0,0q�6]   $	��Top=�6q   $	��230��6�   $	��144��6�   $��2��6�   �� 57   
   ���	#FF40648F$
��Left=�6%   $��38��6@   
���   �$	��Top=�6[   $
��1195��6s   $��3��6�   $��0,880,0,-0.5q�6�   5:      5;      