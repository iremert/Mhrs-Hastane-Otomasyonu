# -*- coding: utf-8 -*-
"""
Created on Wed May 31 16:19:59 2023

@author: lenovo
"""

#kütüphane
import sys
from PyQt5 import QtWidgets
from PyQt5.QtWidgets import QMainWindow,QApplication,QLineEdit,QDateEdit,QTableWidget,QPushButton,QTableWidgetItem #push button tab içine eklemek için gerekti
from PyQt5.QtWidgets import QMessageBox,QHeaderView,QFileDialog #table için
from PyQt5.QtCore import QTimer
from PyQt5.QtCore import QDate
#import time
from PyQt5.QtWidgets import QWidget
from PyQt5.QtWidgets import QButtonGroup
from PyQt5.QtGui import QPixmap,QIcon #resim
from PyQt5.QtCore import QSize #resim


from PyQt5 import uic,QtCore #animasyon için

from AnaSayfaa import *
from BiletAlım import *
from Filmİşlemleri import *
from FilmListeleme import *
from KullanıcıPaneli import *
from YöneticiPaneli import *
from Seansİşlemi import *
from Salonİşlemleri import *
from Satışİşlemleri import *
from YoneticiIslemleri import *
from hakkinda import *


#sayfalarımızın açım işlemlerini yapalım
app1=QApplication(sys.argv)
window1=QMainWindow()
ui1=Ui_AnaSayfaa()
ui1.setupUi(window1)

app2=QApplication(sys.argv)
window2=QMainWindow()
ui2=Ui_BiletAlm()
ui2.setupUi(window2)

app3=QApplication(sys.argv)
window3=QMainWindow()
ui3=Ui_KullaniciPaneli()
ui3.setupUi(window3)

app4=QApplication(sys.argv)
window4=QMainWindow()
ui4=Ui_FilmIslemleri()
ui4.setupUi(window4)

app5=QApplication(sys.argv)
window5=QMainWindow()
ui5=Ui_FilmListeleme()
ui5.setupUi(window5)

app6=QApplication(sys.argv)
window6=QMainWindow()
ui6=Ui_YoneticiPaneli()
ui6.setupUi(window6)

app7=QApplication(sys.argv)
window7=QMainWindow()
ui7=Ui_Seansİşlemi()
ui7.setupUi(window7)

app8=QApplication(sys.argv)
window8=QMainWindow()
ui8=Ui_SalonIslemleri()
ui8.setupUi(window8)

app9=QApplication(sys.argv)
window9=QMainWindow()
ui9=Ui_SatisIslemleri()
ui9.setupUi(window9)

app10=QApplication(sys.argv)
window10=QMainWindow()
ui10=Ui_YoneticIslemleri()
ui10.setupUi(window10)

app11=QApplication(sys.argv)
window11=QMainWindow()
ui11=Ui_hakkinda()
ui11.setupUi(window11)

window1.show()





#database işlemi
import sqlite3
global connection
global cursor
connection=sqlite3.connect("SinemaOtomasyonu.db")
cursor=connection.cursor()





#ana sayfa
ui1.side_menu = 0
def side_menu():
    if ui1.side_menu == 0:
        ui1.animation1 = QtCore.QPropertyAnimation(ui1.frame_4, b"maximumWidth") #animasyon yapabilmek için
        ui1.animation1.setDuration(500)  #süresi,0.5 saniye
        ui1.animation1.setStartValue(37) #boyut
        ui1.animation1.setEndValue(95) #boyut
        ui1.animation1.setEasingCurve(QtCore.QEasingCurve.InOutQuart) #animasyon yumuşak geçişler yapsın diyedir.
        ui1.animation1.start()
        
        ui1.animation2 = QtCore.QPropertyAnimation(ui1.frame_4, b"minimumWidth")
        ui1.animation2.setDuration(500)
        ui1.animation2.setStartValue(37)
        ui1.animation2.setEndValue(95)
        ui1.animation2.setEasingCurve(QtCore.QEasingCurve.InOutQuart)
        ui1.animation2.start()
        
        ui1.side_menu = 1
    else:
        ui1.animation1 = QtCore.QPropertyAnimation(ui1.frame_4, b"maximumWidth")
        ui1.animation1.setDuration(500)
        ui1.animation1.setStartValue(95)
        ui1.animation1.setEndValue(37)
        ui1.animation1.setEasingCurve(QtCore.QEasingCurve.InOutQuart)
        ui1.animation1.start()
        
        ui1.animation2 = QtCore.QPropertyAnimation(ui1.frame_4, b"minimumWidth")
        ui1.animation2.setDuration(500)
        ui1.animation2.setStartValue(95)
        ui1.animation2.setEndValue(37)
        ui1.animation2.setEasingCurve(QtCore.QEasingCurve.InOutQuart)
        ui1.animation2.start()
        
        ui1.side_menu = 0
def side_menu_1(Event):
    if Event.button()==QtCore.Qt.LeftButton: #sol butonsa olay
        ui1.animation1 = QtCore.QPropertyAnimation(ui1.frame_4, b"maximumWidth")
        ui1.animation1.setDuration(500)
        ui1.animation1.setStartValue(95)
        ui1.animation1.setEndValue(37)
        ui1.animation1.setEasingCurve(QtCore.QEasingCurve.InOutQuart)
        ui1.animation1.start()
        
        ui1.animation2 = QtCore.QPropertyAnimation(ui1.frame_4, b"minimumWidth")
        ui1.animation2.setDuration(500)
        ui1.animation2.setStartValue(95)
        ui1.animation2.setEndValue(37)
        ui1.animation2.setEasingCurve(QtCore.QEasingCurve.InOutQuart)
        ui1.animation2.start()
    else:
        pass
ui1.toolButton.clicked.connect(lambda: side_menu()) 
ui1.frame_5.mousePressEvent=side_menu_1 #mouse olayı varsa



def YonetıcıPanelı():
    window6.show()
    window1.close()
def KullanıcıPanelı():
    window3.show()
    window1.close()
def Cıkıs():
    window1.close()
def hakkında():
    window11.show()
ui1.pushButton_3.clicked.connect(YonetıcıPanelı)
ui1.pushButton_6.clicked.connect(KullanıcıPanelı)
ui1.pushButton_5.clicked.connect(Cıkıs)

ui1.toolButton_2.clicked.connect(YonetıcıPanelı)
ui1.toolButton_4.clicked.connect(KullanıcıPanelı)
ui1.toolButton_3.clicked.connect(hakkında)











#renk sıfırlama:rezervasyon kısmı için gerekiyor
def sıfırla():
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










#kullanıcı paneli
def KullanıcıOluştur():
    try:
        Ad_Soyad=ui3.lineEdit_1.text()
        Kullanıcı_Adı=ui3.lineEdit_2.text()
        Şifre=ui3.lineEdit_4.text()
        Şifre_Tekrarı=ui3.lineEdit_3.text()
        Tel=ui3.lineEdit_5.text()
        Email=ui3.lineEdit_6.text()
        
        if  Şifre!="" and Ad_Soyad!="" and Kullanıcı_Adı!="" and Şifre_Tekrarı!="" and Tel!="" and Email!="":
            if Şifre==Şifre_Tekrarı:
                QMessageBox.question(window3,"Kullanıcı Oluştur","Kullanıcı oluşturulsun mu?",QMessageBox.Ok | QMessageBox.Cancel)
                if QMessageBox.Ok:
                    cursor.execute("Insert into Kullanıcılar (Ad_Soyad,Kullanıcı_Adı,Şifre,Şifre_Tekrarı,Tel,Email) values (?,?,?,?,?,?)",(Ad_Soyad,Kullanıcı_Adı,Şifre,Şifre_Tekrarı,Tel,Email))                      
                    connection.commit()
                    ui3.statusbar.showMessage("Kullanıcı oluşturuldu.",3000)
                    ui3.lineEdit_1.clear()
                    ui3.lineEdit_2.clear()
                    ui3.lineEdit_3.clear()
                    ui3.lineEdit_4.clear()
                    ui3.lineEdit_5.clear()
                    ui3.lineEdit_6.clear()
            else:
                ui3.statusbar.showMessage("Girdiğiniz şifreler uyuşmuyor,lütfen kontrol ediniz!",3000)
        else:
            ui3.statusbar.showMessage("Boş bıraktığınız alanlar var,lütfen doldurunuz!",3000)
    except sqlite3.IntegrityError:
        ui3.statusbar.showMessage("Önceden bu adları kullanmışsınız, lütfen tekrardan deneyiniz!")
def KullanıcıGirişi():
    Kullanıcı_Adı=ui3.lineEdit_8.text()
    Şifre=ui3.lineEdit_10.text()
    cursor.execute("Select * from Kullanıcılar where Kullanıcı_Adı=? and Şifre=? ",(Kullanıcı_Adı,Şifre))
    if cursor.fetchone() is not None:
        QMessageBox.question(window3,"Kullanıcı Girişi","Kullanıcı girişi yapılsın mı?",QMessageBox.Ok | QMessageBox.Cancel)
        if QMessageBox.Ok:
            ui3.lineEdit_8.clear()
            ui3.lineEdit_10.clear()
            window3.close()
            window2.show()
        
            
            #rezervasyon kısmı
            ui2.comboBox.clear()
            
            cursor.execute("select FilmAdıId from Seanslar")
            a=cursor.fetchall()
            liste_4=[]
            for kk in a:
                liste_4.append(kk[0])
            liste_4=set(liste_4)
            liste_4=list(liste_4)
            for b in liste_4:
                cursor.execute("select Film_Adı from Filmler where FilmId=?",(b,))
                kp=cursor.fetchone()
                ui2.comboBox.addItem(kp[0])
            ui2.comboBox.setCurrentIndex(-1)
            
            def işlem_1():
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
                sıfırla()
                        
            def işlem_2():
                ui2.comboBox_3.clear()
                film=ui2.comboBox.currentText() 
                cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
                b=cursor.fetchone()
                
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
                    for w in cursor.fetchall():
                        ui2.comboBox_3.addItem(w[0])
                        ui2.comboBox_3.setCurrentIndex(-1) 
                sıfırla()
            
            def işlem_3():
                ui2.comboBox_4.clear()
                film=ui2.comboBox.currentText() 
                cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
                b=cursor.fetchone()
                
                salons=ui2.comboBox_2.currentText()
                cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(salons,))
                h=cursor.fetchone()
                
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
                sıfırla()
            
            
            ui2.comboBox.currentIndexChanged.connect(işlem_1)
            ui2.comboBox_2.currentIndexChanged.connect(işlem_2)
            ui2.comboBox_3.currentIndexChanged.connect(işlem_3)
                   
    else:
        ui3.statusbar.showMessage("Böyle bir kullanıcı bulunumadı,lütfen tekrar deneyiniz yada kullanıcı oluşturunuz!",3000)
    
def AnaSayfayaDön():
    window3.close()
    window1.show()
    
    
def ŞifreGöster(): 
    pass
"""if ui3.checkBox.isChecked()==False:
        ui3.lineEdit_4.setEchoMode(QLineEdit.Password)
    else:
        ui3.lineEdit_4.setEchoMode(QLineEdit.Normal)
    if ui3.checkBox_2.isChecked():
        print("truee")
        ui3.lineEdit_3.setEchoMode(QLineEdit.Normal)
    else:
        ui3.lineEdit_3.setEchoMode(QLineEdit.Password) 
    if ui3.checkBox_3.isChecked():
        print("trueee")
        ui3.lineEdit_10.setEchoMode(QLineEdit.Normal)
    else:
        ui3.lineEdit_10.setEchoMode(QLineEdit.Password)"""
        
def şifre1():
    ui3.lineEdit_4.setEchoMode(QLineEdit.Normal)
    QTimer.singleShot(2000, lambda: ui3.lineEdit_4.setEchoMode(QLineEdit.Password))
    #ui3.lineEdit_4.setEchoMode(QLineEdit.Normal)
    #time.sleep(2)
    #ui3.lineEdit_4.setEchoMode(QLineEdit.Password)
    
def şifre2():
    ui3.lineEdit_3.setEchoMode(QLineEdit.Normal)
    QTimer.singleShot(2000, lambda: ui3.lineEdit_3.setEchoMode(QLineEdit.Password))
    
def şifre3():
    ui3.lineEdit_10.setEchoMode(QLineEdit.Normal)
    QTimer.singleShot(2000, lambda: ui3.lineEdit_10.setEchoMode(QLineEdit.Password))
    
ui3.pushButton_4.clicked.connect(şifre1)
ui3.pushButton_5.clicked.connect(şifre2)
ui3.pushButton_6.clicked.connect(şifre3)
ui3.pushButton.clicked.connect(KullanıcıOluştur)
ui3.pushButton_2.clicked.connect(KullanıcıGirişi)
ui3.pushButton_3.clicked.connect(AnaSayfayaDön)










#yönetici paneli
def YöneticiOluştur():
    try:
        Ad_Soyad=ui6.lineEdit_1.text()
        Yönetici_Adı=ui6.lineEdit_2.text()
        Şifre=ui6.lineEdit_4.text()
        Şifre_Tekrarı=ui6.lineEdit_3.text()
        Tel=ui6.lineEdit_5.text()
        Email=ui6.lineEdit_6.text()
        
        if  Şifre!="" and Ad_Soyad!="" and Yönetici_Adı!="" and Şifre_Tekrarı!="" and Tel!="" and Email!="":
            if Şifre==Şifre_Tekrarı:
                QMessageBox.question(window6,"Yönetici Oluştur","Yönetici oluşturulsun mu?",QMessageBox.Ok | QMessageBox.Cancel)
                if QMessageBox.Ok:
                    cursor.execute("Insert into Yöneticiler (Ad_Soyad,Yönetici_Adı,Şifre,Şifre_Tekrarı,Tel,Email) values (?,?,?,?,?,?)",(Ad_Soyad,Yönetici_Adı,Şifre,Şifre_Tekrarı,Tel,Email))                      
                    connection.commit()
                    ui6.statusbar.showMessage("Yönetici oluşturuldu.",3000)
                    ui6.lineEdit_1.clear()
                    ui6.lineEdit_2.clear()
                    ui6.lineEdit_3.clear()
                    ui6.lineEdit_4.clear()
                    ui6.lineEdit_5.clear()
                    ui6.lineEdit_6.clear()
            else:
                ui6.statusbar.showMessage("Girdiğiniz şifreler uyuşmuyor,lütfen kontrol edini!",3000)
        else:
            ui6.statusbar.showMessage("Boş bıraktığınız alanlar var,lütfen doldurunuz!",3000)
    except sqlite3.IntegrityError:
        ui6.statusbar.showMessage("Önceden bu adları kullanmışsınız, lütfen tekrardan deneyiniz!")
def YöneticiGirişi():
    Yönetici_Adı=ui6.lineEdit_8.text()
    Şifre=ui6.lineEdit_10.text()
    cursor.execute("Select * from Yöneticiler where Yönetici_Adı=? and Şifre=? ",(Yönetici_Adı,Şifre))
    if cursor.fetchone() is not None:
        QMessageBox.question(window6,"Yönetici Girişi","Yönetici girişi yapılsın mı?",QMessageBox.Ok | QMessageBox.Cancel)
        if QMessageBox.Ok:
            window10.show()
            window6.close()
            ui6.lineEdit_8.clear()
            ui6.lineEdit_10.clear()
            
    else:
        ui6.statusbar.showMessage("Böyle bir kullanıcı bulunumadı,lütfen tekrar deneyiniz yada kullanıcı oluşturunuz!",3000)
    
def AnaSayfayaDön():
    window6.close()
    window1.show()
    
    
def şifre1():
    ui6.lineEdit_4.setEchoMode(QLineEdit.Normal) 
    QTimer.singleShot(2000, lambda: ui6.lineEdit_4.setEchoMode(QLineEdit.Password)) #süre için gerekir.
    #ui3.lineEdit_4.setEchoMode(QLineEdit.Normal)
    #time.sleep(2)
    #ui3.lineEdit_4.setEchoMode(QLineEdit.Password)
    
def şifre2():
    ui6.lineEdit_3.setEchoMode(QLineEdit.Normal)
    QTimer.singleShot(2000, lambda: ui6.lineEdit_3.setEchoMode(QLineEdit.Password))
    
def şifre3():
    ui6.lineEdit_10.setEchoMode(QLineEdit.Normal)
    QTimer.singleShot(2000, lambda: ui6.lineEdit_10.setEchoMode(QLineEdit.Password))
    
ui6.pushButton_4.clicked.connect(şifre1)
ui6.pushButton_5.clicked.connect(şifre2)
ui6.pushButton_6.clicked.connect(şifre3)
ui6.pushButton.clicked.connect(YöneticiOluştur)
ui6.pushButton_2.clicked.connect(YöneticiGirişi)
ui6.pushButton_3.clicked.connect(AnaSayfayaDön)










#yönetici işlemleri
def SalonEkle():
    window10.close()
    window8.show()
def Filmİşlemleri():
    window10.close()
    window4.show()
def FilmListeleme():
    window10.close()
    window5.show()
def SeansEkle():
    window10.close()
    window7.show()
    
    ui7.comboBox.clear()
    cursor.execute("select Film_Adı from Filmler")
    a=cursor.fetchall()
    a=list(a)
    for b in a:
        ui7.comboBox.addItem(b[0])
    ui7.comboBox.setCurrentIndex(-1)

    ui7.comboBox_2.clear()
    cursor.execute("select Salon_Adı from Salonlar")
    a=cursor.fetchall()
    a=list(a)
    for b in a:
        ui7.comboBox_2.addItem(b[0])
    ui7.comboBox_2.setCurrentIndex(-1)

def Satışlar():
    window10.close()
    window9.show()
def AnaSayfayaDön():
    window10.close()
    window1.show()
ui10.pushButton.clicked.connect(SalonEkle)
ui10.pushButton_3.clicked.connect(Filmİşlemleri)
ui10.pushButton_5.clicked.connect(FilmListeleme)
ui10.pushButton_2.clicked.connect(SeansEkle)
ui10.pushButton_4.clicked.connect(Satışlar)
ui10.pushButton_27.clicked.connect(AnaSayfayaDön)










#salon ekle
def SalonEkle(): 
    try:
        salon_adı=ui8.lineEdit_1.text()
        QMessageBox.question(window10,"Salon Ekleme","Salon eklensin mi?",QMessageBox.Ok | QMessageBox.Close)
        if QMessageBox.Ok:
            cursor.execute("Insert into Salonlar (Salon_Adı) values(?)",(salon_adı,))
            connection.commit()
            ui8.statusbar.showMessage("Salon oluşturuldu.",3000)
            ui8.lineEdit_1.clear()
    except sqlite3.IntegrityError:
        ui8.statusbar.showMessage("Önceden bu salon adı girilmiş, lütfen tekrardan deneyiniz!")
def GeriDön():
    window8.close()
    window10.show()
ui8.pushButton_3.clicked.connect(SalonEkle)
ui8.pushButton_2.clicked.connect(GeriDön)










def displayImage(file_path):
    pixmap = QPixmap(file_path)
    ui4.label.setPixmap(pixmap)
    ui4.label.setScaledContents(True)
    
def openFileDialog():
    options = QFileDialog.Options()
    options |= QFileDialog.DontUseNativeDialog
    fileName, _ = QFileDialog.getOpenFileName(None, "Dosya Seç", "", "Tüm Dosyalar (*);;Metin Dosyaları (*.txt)", options=options)
    resimUrl=fileName
    
    cursor.execute("insert into Resimler (ResimUrl) values (?)",(resimUrl,))
    connection.commit()
    displayImage(resimUrl) 
 
    
 
#film işlemleri
def FilmEkle(): 
    try:
        QMessageBox.question(window4,"Film Ekle","Film eklensin mi?",QMessageBox.Ok | QMessageBox.Close)
        Film_adı=ui4.lineEdit_2.text()
        Yönetmen=ui4.lineEdit_3.text()
        Vizyon_tarihi=ui4.dateEdit.text()
        Film_süresi=ui4.lineEdit_1.text()
        Film_türü=ui4.comboBox_4.currentText()
        oyuncular=ui4.textEdit.toPlainText()
        cursor.execute("select ResimId from Resimler")
        resimId=cursor.fetchall()[-1][0]
        
        if QMessageBox.Ok:
            cursor.execute("Insert into Filmler (Film_Adı,Yönetmen,Vizyon_Tarihi,Film_Süresi,Film_Türü,Oyuncular,ResimId) values(?,?,?,?,?,?,?)",(Film_adı,Yönetmen,Vizyon_tarihi,Film_süresi,Film_türü,oyuncular,resimId))           
            connection.commit()
            ui4.lineEdit_2.clear()
            ui4.lineEdit_3.clear()
            ui4.lineEdit_1.clear()
            ui4.comboBox_4.setCurrentIndex(-1)
            ui4.textEdit.clear()
            original_date=QDate(2000, 1, 1)
            ui4.dateEdit.setDate(original_date)
            ui4.statusbar.showMessage("Film eklendi.",4000)
            ui4.label.clear()
            
    except sqlite3.IntegrityError:
        ui4.statusbar.showMessage("Önceden bu filmi girmişsiniz, lütfen tekrardan deneyiniz!")

def GeriDön():
    window4.close()
    window10.show()
def FilmSil():
    QMessageBox.question(window4,"Film Sil","Film silinsin mi?",QMessageBox.Ok | QMessageBox.Close)
    if QMessageBox.Ok:
        sil=ui4.lineEdit_5.text()
        cursor.execute("select * from Filmler where Film_Adı=?",(sil,))
        if cursor.fetchone() is not None:
            cursor.execute("delete from Filmler where Film_Adı=?",(sil,))
            connection.commit()
            ui4.lineEdit_5.clear()
            ui4.statusbar.showMessage("Film silindi.",3000)
        else:
            ui4.statusbar.showMessage("Böyle bir film bulunmamakta,lütfen yeniden deneyiniz!")     
def FilmGüncelle():
    QMessageBox.question(window4,"Film Güncelleme","Film güncellensin mi?",QMessageBox.Ok | QMessageBox.Close)
    if QMessageBox.Ok:
        güncelle=ui4.lineEdit_4.text()
        cursor.execute("select * from Filmler where Film_Adı=?",(güncelle,))
        film=cursor.fetchone()
        a,b,c,d,e,f=True,True,True,True,True,True
        if film is not None:
            film=list(film)
            Film_adı=ui4.lineEdit_2.text()
            Yönetmen=ui4.lineEdit_3.text()
            Vizyon_tarihi=ui4.dateEdit.text()
            Film_süresi=ui4.lineEdit_1.text()
            Film_türü=ui4.comboBox_4.currentText()
            oyuncular=ui4.textEdit.toPlainText()
            original_date=QDate(2000, 1, 1)
            if Film_adı!="":
                a=False
                film[1]=Film_adı
            if Yönetmen!="":
                b=False
                film[2]=Yönetmen
            if Vizyon_tarihi!=original_date:
                c=False
                film[3]=Vizyon_tarihi
            if Film_süresi!="":
                d=False
                film[4]=Film_süresi
            if Film_türü!="":
                e=False
                film[5]=Film_türü
            if oyuncular!="":
                f=False
                film[6]=oyuncular
            
            cursor.execute("Update Filmler set Film_Adı=? , Yönetmen=? , Vizyon_Tarihi=? , Film_Süresi=? , Film_Türü=? , Oyuncular=? where Film_Adı=?",(film[1],film[2],film[3],film[4],film[5],film[6],güncelle))
            connection.commit()
            ui4.statusbar.showMessage("Film güncellendi.",3000)
            if a==False:
                ui4.lineEdit_2.clear()
            if b==False:
                ui4.lineEdit_3.clear()
            if c==False:
                original_date=QDate(2000, 1, 1)
                ui4.dateEdit.setDate(original_date)
            if d==False:
                ui4.lineEdit_1.clear()
            if e==False:
                ui4.comboBox_4.setCurrentIndex(-1)
            if f==False:
                ui4.textEdit.clear()
            ui4.lineEdit_4.clear()
            
        else:
            ui4.statusbar.showMessage("Böyle bir film bulunmamakta lütfen yeniden deneyiniz!",3000)
ui4.pushButton.clicked.connect(FilmEkle)
ui4.pushButton_2.clicked.connect(GeriDön)
ui4.pushButton_4.clicked.connect(FilmSil)
ui4.pushButton_3.clicked.connect(FilmGüncelle)
ui4.pushButton_5.clicked.connect(openFileDialog)










#giriş bilgilerini alınacakları üstteki yere gönderdim
#seans işlemleri
def bak(): #checkbox yakma işlemi
    def sıfırlamak(): 
        ui7.checkBox.setChecked(False)
        ui7.checkBox_2.setChecked(False)
        ui7.checkBox_3.setChecked(False)
        ui7.checkBox_4.setChecked(False)
        ui7.checkBox_5.setChecked(False)
        ui7.checkBox_6.setChecked(False)
        ui7.checkBox_19.setChecked(False)
        ui7.checkBox_20.setChecked(False)
        ui7.checkBox_21.setChecked(False)
        ui7.checkBox_22.setChecked(False)
        ui7.checkBox_23.setChecked(False)
        ui7.checkBox_24.setChecked(False)
    ui7.comboBox.currentIndexChanged.connect(sıfırlamak)
    
    Film_Adı=ui7.comboBox.currentText()
    cursor.execute("select FilmId from Filmler where Film_Adı=?",(Film_Adı,))
    a=cursor.fetchone()
    Salon_Adı=ui7.comboBox_2.currentText()
    cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(Salon_Adı,))
    c=cursor.fetchone()
    try:
        tarih=ui7.dateEdit_2.text()
        cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
        b=cursor.fetchone()
        cursor.execute("SELECT FilmSeansıSaatiId FROM Seanslar WHERE FilmAdıId=? AND FilmSeansTarihiId=? AND SalonId=?", (a[0], b[0], c[0]))
        saatler=cursor.fetchall()  
        list_3=[] 
        for saat in saatler:
            cursor.execute("select Saat from Saat where FilmSeansıSaatiId=?",(saat[0],))
            saat_1=cursor.fetchone()
            list_3.append(saat_1[0])
        
        
        
        for saattt in list_3:
            if ui7.checkBox.text()==saattt:
                ui7.checkBox.setChecked(True)
            if ui7.checkBox_2.text()==saattt:
                ui7.checkBox_2.setChecked(True)
            if ui7.checkBox_3.text()==saattt:
                ui7.checkBox_3.setChecked(True)
            if ui7.checkBox_4.text()==saattt:
                ui7.checkBox_4.setChecked(True)
            if ui7.checkBox_5.text()==saattt:
                ui7.checkBox_5.setChecked(True)
            if ui7.checkBox_6.text()==saattt:
                ui7.checkBox_6.setChecked(True)
            if ui7.checkBox_19.text()==saattt:
                ui7.checkBox_19.setChecked(True)
            if ui7.checkBox_20.text()==saattt:
                ui7.checkBox_20.setChecked(True)
            if ui7.checkBox_21.text()==saattt:
                ui7.checkBox_21.setChecked(True)
            if ui7.checkBox_22.text()==saattt:
                ui7.checkBox_22.setChecked(True)
            if ui7.checkBox_23.text()==saattt:
                ui7.checkBox_23.setChecked(True)
            if ui7.checkBox_24.text()==saattt:
                ui7.checkBox_24.setChecked(True)
    except:
        pass

def seansekle():
    try:
        QMessageBox.question(window7,"Seans Ekleme","Seans eklensin mi?",QMessageBox.Ok | QMessageBox.Close)
        if QMessageBox.Ok:
            Film_Adı=ui7.comboBox.currentText()
            cursor.execute("select FilmId from Filmler where Film_Adı=?",(Film_Adı,))
            a=cursor.fetchone()    
            
            Salon_Adı=ui7.comboBox_2.currentText()
            cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(Salon_Adı,))
            c=cursor.fetchone()
            l=True
            tarih=ui7.dateEdit_2.text()
            cursor.execute("select Tarih from Tarih")
            for f in cursor.fetchall():
                if tarih==f[0]:
                    cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,)) 
                    b=cursor.fetchone()
                    l=False
            if l==True:   
                cursor.execute("insert into Tarih(Tarih) values(?)",(tarih,))
                connection.commit()
                cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
                b=cursor.fetchone()
                
            list_1=[]
            list_2=[]
            
            if ui7.checkBox.isChecked():
                list_1.append(ui7.checkBox.text())
            if ui7.checkBox_2.isChecked():
                list_1.append(ui7.checkBox_2.text())
            if ui7.checkBox_3.isChecked():
                list_1.append(ui7.checkBox_3.text())
            if ui7.checkBox_4.isChecked():
                list_1.append(ui7.checkBox_4.text())
            if ui7.checkBox_5.isChecked():
                list_1.append(ui7.checkBox_5.text())
            if ui7.checkBox_6.isChecked():
                list_1.append(ui7.checkBox_6.text())
            if ui7.checkBox_19.isChecked():
                list_1.append(ui7.checkBox_19.text())
            if ui7.checkBox_20.isChecked():
                list_1.append(ui7.checkBox_20.text())
            if ui7.checkBox_21.isChecked():
                list_1.append(ui7.checkBox_21.text())
            if ui7.checkBox_22.isChecked():
                list_1.append(ui7.checkBox_22.text())
            if ui7.checkBox_23.isChecked():
                list_1.append(ui7.checkBox_23.text())
            if ui7.checkBox_24.isChecked():
                list_1.append(ui7.checkBox_24.text())
            for k in list_1:
                cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(k,))
                e=cursor.fetchone()
                list_2.append(e[0])
            
            for d in list_2:
                cursor.execute("insert into  Seanslar(FilmAdıId,FilmSeansTarihiId,SalonId,FilmSeansıSaatiId) values(?,?,?,?)",(a[0],b[0],c[0],d))
                connection.commit()
                
            ui7.comboBox.setCurrentIndex(-1)
            original_date=QDate(2000, 1, 1)
            ui7.dateEdit_2.setDate(original_date)
            ui7.comboBox_2.setCurrentIndex(-1)
            ui7.checkBox.setChecked(False)
            ui7.checkBox_2.setChecked(False)
            ui7.checkBox_3.setChecked(False)
            ui7.checkBox_4.setChecked(False)
            ui7.checkBox_5.setChecked(False)
            ui7.checkBox_6.setChecked(False)
            ui7.checkBox_19.setChecked(False)
            ui7.checkBox_20.setChecked(False)
            ui7.checkBox_21.setChecked(False)
            ui7.checkBox_22.setChecked(False)
            ui7.checkBox_23.setChecked(False)
            ui7.checkBox_24.setChecked(False)
            ui7.statusbar.showMessage("Seans eklendi.",3000)
    except sqlite3.IntegrityError:
         ui7.statusbar.showMessage("Önceden bu seans girilmiş, lütfen tekrardan deneyiniz!")   #gereksiz         
def geridön():
    window7.close()
    window10.show()
ui7.pushButton.clicked.connect(seansekle)
ui7.pushButton_2.clicked.connect(geridön)
ui7.comboBox_2.currentIndexChanged.connect(bak)












#listeleme işlemleri:300 row ekledim
def filmlistele():
    ui5.tableWidget.setHorizontalHeaderLabels(("Film kodu","Film adı", "Yönetmen", "Vizyon tarihi", "Film süresi", "Film türü", "Oyuncular"))

    cursor.execute("select * from Filmler")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui5.tableWidget.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))
 
def salonlistele():
    ui5.tableWidget_2.setHorizontalHeaderLabels(("Salon kodu","Salon adı"))

    cursor.execute("select * from Salonlar")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui5.tableWidget_2.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))
 
def seanslistele():
    ui5.tableWidget_3.setHorizontalHeaderLabels(("Seans kodu","Film adı", "Film tarihi", "Salon adı", "Film saati"))

    cursor.execute("select * from Seanslar")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui5.tableWidget_3.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))

def saatlistele():
    ui5.tableWidget_4.setHorizontalHeaderLabels(("Saat kodu","Film saati"))

    cursor.execute("select * from Saat")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui5.tableWidget_4.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))

def tarihlistele():
    ui5.tableWidget_5.setHorizontalHeaderLabels(("Tarih kodu","Film tarihi"))

    cursor.execute("select * from Tarih")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui5.tableWidget_5.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))

def geridönn():
    ui5.tableWidget.clear()
    ui5.tableWidget_2.clear()
    ui5.tableWidget_3.clear()
    window5.close()
    window10.show()
ui5.pushButton_4.clicked.connect(geridönn)

tab1 = ui5.tabWidget.findChild(QWidget, "tab")
tab2 = ui5.tabWidget.findChild(QWidget, "tab_2")  
tab3 = ui5.tabWidget.findChild(QWidget, "tab_3")
tab4 =ui5.tabWidget.findChild(QWidget,"tab_4")
tab5 =ui5.tabWidget.findChild(QWidget,"tab_5")

button1 = tab1.findChild(QPushButton, "pushButton") 
button1.clicked.connect(filmlistele)

button2 = tab2.findChild(QPushButton, "pushButton_3") 
button2.clicked.connect(seanslistele)

button3 = tab3.findChild(QPushButton, "pushButton_2") 
button3.clicked.connect(salonlistele)

button4 = tab4.findChild(QPushButton,"pushButton_5")
button4.clicked.connect(saatlistele)

button5 = tab5.findChild(QPushButton,"pushButton_6")
button5.clicked.connect(tarihlistele)















#satış işlemleri
def satışlistele():
    ui9.tableWidget.setHorizontalHeaderLabels(("Rezervasyon kodu","Film adı", "Salon adı", "Tarih", "Saat","Müşteri ad-soyad","Koltuk no","Ücret"))

    cursor.execute("select * from Rezervasyonlar")
    for satırIndexs, satırveri in enumerate(cursor):
        for sutunIndeks, sutunVeri in enumerate(satırveri):
            ui9.tableWidget.setItem(satırIndexs, sutunIndeks, QTableWidgetItem(str(sutunVeri)))
    
    cursor.execute("select Ücret from Rezervasyonlar")
    ücrets=cursor.fetchall()
    toplam=0
    #print(ücrets) kaydederken galiba virgülle kaydettik ücretleri yo öylede yapmadık da böyle oluyor demekki tekli olunca :)))
    for ücret in ücrets:
        #print(ücret) garips
        toplam=toplam+int(ücret[0])
    ui9.label_4.setText(str(toplam))

ui9.pushButton_3.clicked.connect(satışlistele)
def geridönnn():
    ui9.label_4.setText("")
    ui9.tableWidget.clear()
    window9.close()
    window10.show()
ui9.pushButton_2.clicked.connect(geridönnn)













def resimekle():
    filmm=ui2.comboBox.currentText()
    cursor.execute("select ResimId from Filmler where Film_Adı=?",(filmm,))
    resimID=cursor.fetchone()[0]
    cursor.execute("select ResimUrl from Resimler where ResimId=?",(resimID,))
    resimUrl=cursor.fetchone()[0]
    
    #icon = QIcon(resimUrl)
    #ui2.pushButton_21.setIcon(icon)
    #ui2.pushButton_21.show()
    
    icon = QIcon.fromTheme(resimUrl)
    pixmap = icon.pixmap(QSize(250, 250))
    new_icon = QIcon(pixmap)
    
    ui2.pushButton_21.setIcon(new_icon)
    ui2.pushButton_21.setIconSize(QSize(250, 250))
    ui2.pushButton_21.show()
    
    #?
    #en başta hep uçurtma avcısı resmi geliyor...


#giriş bilgilerini kullanıcı paneline gönderdim
def satınal():
    
    film=ui2.comboBox.currentText() 
    cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
    b=cursor.fetchone()
    
    salons=ui2.comboBox_2.currentText()
    cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(salons,))
    h=cursor.fetchone()
    
    tarih=ui2.comboBox_3.currentText()
    cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
    o=cursor.fetchone()
    
    rr=ui2.comboBox_4.currentText()
    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(rr,))
    kk=cursor.fetchone()
    
    Ad_Soyad=ui2.lineEdit_1.text()
    koltuk_no=ui2.comboBox_6.currentText()
    
    if ui2.radioButton_1.isChecked()==True:
        ücret=12
    if ui2.radioButton_2.isChecked()==True:
        ücret=10
        
    cursor.execute("insert into Rezervasyonlar(FilmAdıId,SalonId,FilmSeansTarihiId,FilmSeansıSaatiId,Ad_Soyad,Koltuk_No,Ücret) values (?,?,?,?,?,?,?)",(b[0],h[0],o[0],kk[0],Ad_Soyad,koltuk_no,ücret))
    connection.commit()
    ui2.statusbar.showMessage("BİLETİNİZ SATIN ALINDI :)",5000)
    ui2.comboBox.setCurrentIndex(-1)
    ui2.comboBox_2.setCurrentIndex(-1)
    ui2.comboBox_3.setCurrentIndex(-1)
    ui2.comboBox_4.setCurrentIndex(-1)
    ui2.comboBox_6.setCurrentIndex(-1)
    ui2.lineEdit_1.clear()
    
    
    sıfırla()
    
    #?
    buttonGroup = QButtonGroup()
    buttonGroup.addButton(ui2.radioButton_1)
    buttonGroup.addButton(ui2.radioButton_2)
    
    buttonGroup.setExclusive(False)  # Yalnızca bir radyo düğmesinin seçilebileceğini belirtir
    buttonGroup.setExclusive(False) # Yalnızca bir radyo düğmesinin seçilebileceğini kaldırır
    buttonGroup.checkedButton().setChecked(False)
    
    #resim sil
    ui2.pushButton_21.setIcon(QIcon())  # Clear the icon
    ui2.pushButton_21.setIconSize(QSize(0, 0))
        
ui2.pushButton_2.clicked.connect(satınal)
ui2.comboBox.currentIndexChanged.connect(resimekle)





    






#iptal işlemi
def iptal():
    film=ui2.comboBox.currentText() 
    cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
    b=cursor.fetchone()
    
    salons=ui2.comboBox_2.currentText()
    cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(salons,))
    h=cursor.fetchone()
    
    tarih=ui2.comboBox_3.currentText()
    cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
    o=cursor.fetchone()
    
    rr=ui2.comboBox_4.currentText()
    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(rr,))
    kk=cursor.fetchone()
    
    koltukiptal=ui2.comboBox_5.currentText()
    cursor.execute("delete from Rezervasyonlar where FilmAdıId=? and SalonId=? and FilmSeansTarihiId=? and FilmSeansıSaatiId=? and Koltuk_No=?",(b[0],h[0],o[0],kk[0],koltukiptal))
    connection.commit()
    ui2.statusbar.showMessage("İptal işleminiz tamamlandı...")
    
    ui2.comboBox.setCurrentIndex(-1)
    ui2.comboBox_2.setCurrentIndex(-1)
    ui2.comboBox_3.setCurrentIndex(-1)
    ui2.comboBox_4.setCurrentIndex(-1)
    
    sıfırla()
    ui2.comboBox_5.setCurrentIndex(-1)
    ui2.pushButton_21.setIcon(QIcon())  # Clear the icon
    ui2.pushButton_21.setIconSize(QSize(0, 0))
ui2.pushButton.clicked.connect(iptal)   










#koltuk işlemi
def koltukişlemi():
    film=ui2.comboBox.currentText()
    cursor.execute("select FilmId from Filmler where Film_Adı=?",(film,))
    film=cursor.fetchone()[0]
    print(film)
    
    salon=ui2.comboBox_2.currentText()
    cursor.execute("select SalonId from Salonlar where Salon_Adı=?",(salon,))
    salon=cursor.fetchone()[0]
    print(salon)
    
    tarih=ui2.comboBox_3.currentText()
    cursor.execute("select FilmSeansTarihiId from Tarih where Tarih=?",(tarih,))
    tarih=cursor.fetchone()[0]
    print(tarih)
    
    saat=ui2.comboBox_4.currentText()
    cursor.execute("select FilmSeansıSaatiId from Saat where Saat=?",(saat,))
    saat=cursor.fetchone()[0]
    print(saat)
    print()
    
    sıfırla()
    
    if saat!=None and film!=None and salon!=None and tarih!=None:
        cursor.execute("select Koltuk_No from Rezervasyonlar where FilmAdıId=? and SalonId=? and FilmSeansTarihiId=? and FilmSeansıSaatiId=?",(film,salon,tarih,saat))
        liste_5=[]
        for k in cursor.fetchall():
            liste_5.append(str(k[0]))
        
        for koltuk in liste_5:
            if ui2.pushButton_8.text()==koltuk:
                ui2.pushButton_8.setStyleSheet("background-color:yellow")
            if ui2.pushButton_20.text()==koltuk:
                ui2.pushButton_20.setStyleSheet("background-color:yellow")
            if ui2.pushButton_5.text()==koltuk:
                ui2.pushButton_5.setStyleSheet("background-color:yellow")
            if ui2.pushButton_9.text()==koltuk:
                ui2.pushButton_9.setStyleSheet("background-color:yellow")
            if ui2.pushButton_6.text()==koltuk:
                ui2.pushButton_6.setStyleSheet("background-color:yellow")
            if ui2.pushButton_7.text()==koltuk:
                ui2.pushButton_7.setStyleSheet("background-color:yellow")
            if ui2.pushButton_19.text()==koltuk:
                ui2.pushButton_19.setStyleSheet("background-color:yellow")
            if ui2.pushButton_4.text()==koltuk:
                ui2.pushButton_4.setStyleSheet("background-color:yellow")
            if ui2.pushButton_10.text()==koltuk:
                ui2.pushButton_10.setStyleSheet("background-color:yellow")
            if ui2.pushButton_3.text()==koltuk:
                ui2.pushButton_3.setStyleSheet("background-color:yellow")
            if ui2.pushButton_17.text()==koltuk:
                ui2.pushButton_17.setStyleSheet("background-color:yellow")
            if ui2.pushButton_11.text()==koltuk:
                ui2.pushButton_11.setStyleSheet("background-color:yellow")
            if ui2.pushButton_15.text()==koltuk:
                ui2.pushButton_15.setStyleSheet("background-color:yellow")
            if ui2.pushButton_13.text()==koltuk:
                ui2.pushButton_13.setStyleSheet("background-color:yellow")
            if ui2.pushButton_18.text()==koltuk:
                ui2.pushButton_18.setStyleSheet("background-color:yellow")
            if ui2.pushButton_12.text()==koltuk:
                ui2.pushButton_12.setStyleSheet("background-color:yellow")
            if ui2.pushButton_16.text()==koltuk:
                ui2.pushButton_16.setStyleSheet("background-color:yellow")
            if ui2.pushButton_14.text()==koltuk:
                ui2.pushButton_14.setStyleSheet("background-color:yellow")  
ui2.comboBox_4.currentIndexChanged.connect(koltukişlemi)




def geridön():
    window2.close()
    window1.show()
ui2.pushButton_27.clicked.connect(geridön)










#önceden yaptığım koltuk işlemi
"""#?
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
            
            #look
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
"""


#app kapamak
sys.exit(app1.exec_())
sys.exit(app2.exec_())
sys.exit(app3.exec_())
sys.exit(app4.exec_())
sys.exit(app5.exec_())
sys.exit(app6.exec_())
sys.exit(app7.exec_())
sys.exit(app8.exec_())
sys.exit(app9.exec_())
sys.exit(app10.exec_())
