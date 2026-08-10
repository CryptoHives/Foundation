| Description                                | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System    | 1                |  6.640 ns |  0.39 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl | 1                | 16.552 ns |  0.98 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled  | 1                | 16.975 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled  | 1                | 64.162 ns |  3.78 |         - | 
|                                            |                  |           |       |           | 
| SignalAndWait · CountdownEvent · System    | 10               | 20.155 ns |  0.39 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl | 10               | 28.064 ns |  0.54 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled  | 10               | 51.714 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled  | 10               | 79.711 ns |  1.54 |         - |