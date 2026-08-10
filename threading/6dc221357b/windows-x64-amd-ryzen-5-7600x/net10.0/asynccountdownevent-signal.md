| Description                                | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · Standard  | 1                |  6.657 ns |  0.38 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl | 1                | 15.799 ns |  0.90 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled  | 1                | 17.462 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled  | 1                | 46.495 ns |  2.66 |         - | 
|                                            |                  |           |       |           | 
| SignalAndWait · CountdownEvent · Standard  | 10               | 20.122 ns |  0.40 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl | 10               | 27.920 ns |  0.55 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled  | 10               | 50.758 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled  | 10               | 85.093 ns |  1.68 |         - |