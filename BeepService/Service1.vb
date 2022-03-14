Public Class BeepService

    Dim tmrx As New System.Timers.Timer

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Inserire qui il codice necessario per avviare il proprio servizio. Il metodo deve effettuare
        ' le impostazioni necessarie per il funzionamento del servizio.

        AddHandler tmrx.Elapsed, AddressOf Timer_Tick
        tmrx.Interval = 1000
        tmrx.Enabled = True
        tmrx.Start()
        ScriviLog("START")

    End Sub

    Protected Overrides Sub OnStop()
        ' Inserire qui il codice delle procedure di chiusura necessarie per arrestare il proprio servizio.

        tmrx.Enabled = False
        tmrx.Stop()
        ScriviLog("STOP")

    End Sub

    Private Sub ScriviLog(ByVal strTesto As String)

        Dim log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("C:\BeepService.log", True)
        log.WriteLine(Now.ToString & " : " & strTesto)
        log.Close()

    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Beep()

        ScriviLog("BEEP")

    End Sub

End Class
