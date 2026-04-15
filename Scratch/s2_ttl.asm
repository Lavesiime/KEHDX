; ��������������� S U B	R O U T	I N E ���������������������������������������
Deform_TitleScreen:			; CODE XREF: ROM:00003404p

; FUNCTION CHUNK AT 0000620E SIZE 00000056 BYTES

		; Update the background's vertical scrolling.
		move.w	(Camera_BG_Y_pos).w,(Vscroll_Factor_BG).w
		
		; Automatically scroll the background.
		move.w	(Camera_X_pos).w,d0
		cmpi.w	#$1C00,d0
		bcc.s	loc_60B6
		addq.w	#8,d0

loc_60B6:				; CODE XREF: Deform_TitleScreen+Ej
		move.w	d0,(Camera_X_pos).w
		lea	(Horiz_Scroll_Buf).w,a1
		move.w	(Camera_X_pos).w,d2
		neg.w	d2
		moveq	#0,d0
		bra.s	loc_60E4
; ���������������������������������������������������������������������������

Deform_EHZ:				; DATA XREF: ROM:Deform_Indexo
		tst.w	(Two_player_mode).w
		bne.w	Deform_EHZ_2P
		move.w	(Camera_BG_Y_pos).w,(Vscroll_Factor_BG).w
		lea	(Horiz_Scroll_Buf).w,a1
		move.w	(Camera_X_pos).w,d0
		neg.w	d0
		move.w	d0,d2
		swap	d0

loc_60E4:				; CODE XREF: Deform_TitleScreen+22j
		move.w	#0,d0
		move.w	#$15,d1

loc_60EC:				; CODE XREF: Deform_TitleScreen+4Aj
		move.l	d0,(a1)+
		dbf	d1,loc_60EC
		move.w	d2,d0
		asr.w	#6,d0
		move.w	#$39,d1	; '9'

loc_60FA:				; CODE XREF: Deform_TitleScreen+58j
		move.l	d0,(a1)+
		dbf	d1,loc_60FA
		move.w	d0,d3
		move.b	(Vint_runcount+3).w,d1
		andi.w	#7,d1
		bne.s	loc_6110
		subq.w	#1,(TempArray_LayerDef).w

loc_6110:				; CODE XREF: Deform_TitleScreen+66j
		move.w	(TempArray_LayerDef).w,d1
		andi.w	#$1F,d1
		lea	(Deform_EHZ_Data).l,a2
		lea	(a2,d1.w),a2
		move.w	#$14,d1

loc_6126:				; CODE XREF: Deform_TitleScreen+8Aj
		move.b	(a2)+,d0
		ext.w	d0
		add.w	d3,d0
		move.l	d0,(a1)+
		dbf	d1,loc_6126
		move.w	#0,d0
		move.w	#$A,d1

loc_613A:				; CODE XREF: Deform_TitleScreen+98j
		move.l	d0,(a1)+
		dbf	d1,loc_613A
		move.w	d2,d0
		asr.w	#4,d0
		move.w	#$F,d1

loc_6148:				; CODE XREF: Deform_TitleScreen+A6j
		move.l	d0,(a1)+
		dbf	d1,loc_6148
		move.w	d2,d0
		asr.w	#4,d0
		move.w	d0,d1
		asr.w	#1,d1
		add.w	d1,d0
		move.w	#$F,d1

loc_615C:				; CODE XREF: Deform_TitleScreen+BAj
		move.l	d0,(a1)+
		dbf	d1,loc_615C
		move.l	d0,d4
		swap	d4
		move.w	d2,d0
		asr.w	#1,d0
		move.w	d2,d1
		asr.w	#3,d1
		sub.w	d1,d0
		ext.l	d0
		asl.l	#4,d0
		divs.w	#$30,d0	; '0'
		ext.l	d0
		asl.l	#4,d0
		asl.l	#8,d0
		moveq	#0,d3
		move.w	d2,d3
		asr.w	#3,d3
		move.w	#$E,d1

loc_6188:				; CODE XREF: Deform_TitleScreen+EEj
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		swap	d3
		add.l	d0,d3
		swap	d3
		dbf	d1,loc_6188
		move.w	#8,d1

loc_619A:				; CODE XREF: Deform_TitleScreen+106j
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		swap	d3
		add.l	d0,d3
		add.l	d0,d3
		swap	d3
		dbf	d1,loc_619A
		move.w	#$E,d1

loc_61B2:				; CODE XREF: Deform_TitleScreen+124j
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		move.w	d4,(a1)+
		move.w	d3,(a1)+
		swap	d3
		add.l	d0,d3
		add.l	d0,d3
		add.l	d0,d3
		swap	d3
		dbf	d1,loc_61B2
		rts
; End of function Deform_TitleScreen

; ���������������������������������������������������������������������������
Deform_EHZ_Data:dc.b   1,  2,  1,  3,  1,  2,  2,  1,  2,  3,  1,  2,  1,  2,  0,  0; 0
					; DATA XREF: Deform_TitleScreen+74o
					; sub_6264+28t
		dc.b   2,  0,  3,  2,  2,  3,  2,  2,  1,  3,  0,  0,  1,  0,  1,  3; 16
		dc.b   1,  2,  1,  3,  1,  2,  2,  1,  2,  3,  1,  2,  1,  2,  0,  0; 32
		dc.b   2,  0,  3,  2,  2,  3,  2,  2,  1,  3,  0,  0,  1,  0,  1,  3; 48
; ���������������������������������������������������������������������������
; START	OF FUNCTION CHUNK FOR Deform_TitleScreen

Deform_EHZ_2P:
		; Make the 'ripple' animate every 8 frames.
		move.b	(Vint_runcount+3).w,d1
		andi.w	#7,d1
		bne.s	loc_621C
		subq.w	#1,(TempArray_LayerDef).w

loc_621C:
		; Do Player 1's screen.
		
		; Update the background's vertical scrolling.
		move.w	(Camera_BG_Y_pos).w,(Vscroll_Factor_BG).w
		
		; Only allow the screen to vertically scroll two pixels at a time.
		andi.l	#$FFFEFFFE,(Vscroll_Factor).w
		
		; Update the background's (and foreground's) horizontal scrolling.
		; This creates an elaborate parallax effect.
		lea	(Horiz_Scroll_Buf).w,a1
		move.w	(Camera_X_pos).w,d0
		
		; Do 11 lines.
		move.w	#$A,d1
		bsr.s	sub_6264
		
		; Do Player 2's Screen.
		
		; Update the background's vertical scrolling.
		moveq	#0,d0
		move.w	d0,(Vscroll_Factor_P2_BG).w
		subi.w	#$E0,(Vscroll_Factor_P2_BG).w
		move.w	($FFFFEE24).w,($FFFFF61E).w ; Camera_Y_pos_P2?

loc_624A:
		subi.w	#$E0,($FFFFF61E).w ; '�'
		andi.l	#$FFFEFFFE,($FFFFF61E).w
		lea	($FFFFE1B0).w,a1
		move.w	($FFFFEE20).w,d0 ; Camera_X_pos_P2
		move.w	#$E,d1
; END OF FUNCTION CHUNK	FOR Deform_TitleScreen