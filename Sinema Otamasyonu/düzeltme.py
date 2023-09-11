# -*- coding: utf-8 -*-
"""
Created on Tue May 23 12:35:46 2023

@author: lenovo
"""

#?
#rezervasyon işlemi
def işlemler():
    
    #film ekledik aldık ve salon ekledik
    ui2.comboBox_2.clear()
    film=ui2.comboBox.currentText() 
    cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
    b=cursor.fetchone()
    cursor.execute("select SalonId from Seanslar where FilmAdıId=?",(b[0],))
    liste_1=[]
    for d in cursor.fetchall():
        liste_1.append(d[0])
    liste_1=set(liste_1)
    liste_1=list(liste_1)
    for f in liste_1:
        cursor.execute("select Salon_Adı from Salonlar where SalonId=?",(f,))
        for p in cursor.fetchall():
            ui2.comboBox_2.addItem(p[0])
            ui2.comboBox_2.setCurrentIndex(-1)
            
    #tarih ekledik ve salon aldık        
    def tarih():
        ui2.comboBox_3.clear()
        salons=ui2.comboBox_2.currentText()
        cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(salons,))
        h=cursor.fetchone()
        cursor.execute("select FilmSeansTarihiId from Seanslar where FilmAdıId=? and SalonId=?",(b[0],h[0]))
        liste_2=[]
        for y in cursor.fetchall():
            liste_2.append(y[0])
        liste_2=set(liste_2)
        liste_2=list(liste_2)
        for t in liste_2:
            cursor.execute("select Tarih from Tarih where FilmSeansTarihiId=?",(t,))
            for w in cursor.fetchone():
                ui2.comboBox_3.addItem(w)
                ui2.comboBox_3.setCurrentIndex(-1)
                
        #tarih aldık ve filmsaati ekledik   ve iptal      
        def seans():
            ui2.comboBox_4.clear()
            tarih=ui2.comboBox_3.currentText()
            cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
            o=cursor.fetchone()
            cursor.execute("select FilmSeansıSaatiId from Seanslar where FilmAdıId=? and FilmSeansTarihiId=? and SalonId=?",(b[0],o[0],h[0]))
            liste_3=[]
            for y in cursor.fetchall():
                liste_3.append(y[0])
            liste_3=set(liste_3)
            liste_3=list(liste_3)
            for g in liste_3:
                cursor.execute("select Saat from Saat where FilmSeansıSaatiId=?",(g,))
                for z in cursor.fetchall():
                    ui2.comboBox_4.addItem(z[0])
                    ui2.comboBox_4.setCurrentIndex(-1)
            def iptal():
                if QMessageBox.Ok:
                    rr=ui2.comboBox_4.currentText()
                    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(rr,))
                    kk=cursor.fetchone()[0]
                    koltukiptal=ui2.comboBox_5.currentText()
                    cursor.execute("delete from Rezervasyonlar where FilmAdıId=? and SalonId=? and FilmSeansTarihiId=? and FilmSeansıSaatiId=? and Koltuk_No=?",(b[0],h[0],o[0],kk,koltukiptal))
                    connection.commit()
                    ui2.statusbar.showMessage("İptal işleminiz tamamlandı...")
            ui2.pushButton.clicked.connect(iptal)
            #satın almak ayrıca ücret ve seanssaati aldık    
            def radio_1():
                ücret=10
                def satınal_1():
                    rr=ui2.comboBox_4.currentText()
                    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(rr,))
                    kk=cursor.fetchone()[0]
                    Ad_Soyad=ui2.lineEdit_1.text()
                    koltuk_no=ui2.comboBox_6.currentText()
                    cursor.execute("insert into Rezervasyonlar(FilmAdıId,SalonId,FilmSeansTarihiId,FilmSeansıSaatiId,Ad_Soyad,Koltuk_No,Ücret) values (?,?,?,?,?,?,?)",(b[0],h[0],o[0],kk,Ad_Soyad,koltuk_no,ücret))
                    connection.commit()
                    ui2.statusbar.showMessage("BİLETİNİZ SATIN ALINDI :)",5000)
                    ui2.comboBox.setCurrentIndex(-1)
                    ui2.comboBox_2.setCurrentIndex(-1)
                    ui2.comboBox_3.setCurrentIndex(-1)
                    ui2.comboBox_4.setCurrentIndex(-1)
                    ui2.comboBox_6.setCurrentIndex(-1)
                    ui2.lineEdit_1.clear()
                    ui2.pushButton_8.setStyleSheet("")
                    ui2.pushButton_20.setStyleSheet("")
                    ui2.pushButton_5.setStyleSheet("")
                    ui2.pushButton_9.setStyleSheet("")
                    ui2.pushButton_6.setStyleSheet("")
                    ui2.pushButton_7.setStyleSheet("")
                    ui2.pushButton_19.setStyleSheet("")
                    ui2.pushButton_4.setStyleSheet("")
                    ui2.pushButton_10.setStyleSheet("")
                    ui2.pushButton_3.setStyleSheet("")
                    ui2.pushButton_17.setStyleSheet("")
                    ui2.pushButton_11.setStyleSheet("")
                    ui2.pushButton_15.setStyleSheet("")
                    ui2.pushButton_13.setStyleSheet("")
                    ui2.pushButton_18.setStyleSheet("")
                    ui2.pushButton_12.setStyleSheet("")
                    ui2.pushButton_16.setStyleSheet("")
                    ui2.pushButton_14.setStyleSheet("")
                    #?
                    if ui2.radioButton_1.isChecked() or ui2.radioButton_2.isChecked():
                        ui2.radioButton_1.setChecked(False)
                        ui2.radioButton_2.setChecked(False)
                ui2.pushButton_2.clicked.connect(satınal_1)
            def radio_2():  
                ücret=12
                def satınal():
                    rr=ui2.comboBox_4.currentText()
                    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(rr,))
                    kk=cursor.fetchone()[0]
                    Ad_Soyad=ui2.lineEdit.text()
                    koltuk_no=ui2.comboBox_6.currentText()
                    cursor.execute("insert into Rezervasyonlar(FilmAdıId,SalonId,FilmSeansTarihiId,FilmSeansıSaatiId,Ad_Soyad,Koltuk_No,Ücret) values (?,?,?,?,?,?,?)",(b[0],h[0],o,kk,Ad_Soyad,koltuk_no,ücret))
                    connection.commit()
                    ui2.statusbar.showMessage("BİLETİNİZ SATIN ALINDI :)",5000)
                    ui2.comboBox.setCurrentIndex(-1)
                    ui2.comboBox_2.setCurrentIndex(-1)
                    ui2.comboBox_3.setCurrentIndex(-1)
                    ui2.comboBox_4.setCurrentIndex(-1)
                    ui2.comboBox_6.setCurrentIndex(-1)
                    ui2.lineEdit.clear()
                    ui2.pushButton_8.setStyleSheet("")
                    ui2.pushButton_20.setStyleSheet("")
                    ui2.pushButton_5.setStyleSheet("")
                    ui2.pushButton_9.setStyleSheet("")
                    ui2.pushButton_6.setStyleSheet("")
                    ui2.pushButton_7.setStyleSheet("")
                    ui2.pushButton_19.setStyleSheet("")
                    ui2.pushButton_4.setStyleSheet("")
                    ui2.pushButton_10.setStyleSheet("")
                    ui2.pushButton_3.setStyleSheet("")
                    ui2.pushButton_17.setStyleSheet("")
                    ui2.pushButton_11.setStyleSheet("")
                    ui2.pushButton_15.setStyleSheet("")
                    ui2.pushButton_13.setStyleSheet("")
                    ui2.pushButton_18.setStyleSheet("")
                    ui2.pushButton_12.setStyleSheet("")
                    ui2.pushButton_16.setStyleSheet("")
                    ui2.pushButton_14.setStyleSheet("")
                    if ui2.radioButton.isChecked() or ui2.radioButton_2.isChecked():
                        ui2.radioButton.setChecked(False)
                        ui2.radioButton_2.setChecked(False)
                ui2.pushButton_2.clicked.connect(satınal)
                
            ui2.radioButton_2.toggled.connect(radio_1)
            ui2.radioButton_1.toggled.connect(radio_2)   
        ui2.comboBox_3.currentIndexChanged.connect(seans)
    ui2.comboBox_2.currentIndexChanged.connect(tarih)
    
def anasayfayadön():
    window2.close()
    window1.show()
    
ui2.pushButton_27.clicked.connect(anasayfayadön)
ui2.comboBox.currentIndexChanged.connect(işlemler)
