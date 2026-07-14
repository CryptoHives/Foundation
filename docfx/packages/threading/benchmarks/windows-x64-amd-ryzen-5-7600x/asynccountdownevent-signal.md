| Description                                          | ParticipantCount | Mean      | Ratio | Allocated | 
|----------------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System              | 1                |  6.948 ns |  0.90 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise      | 1                |  7.734 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled            | 1                |  7.758 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl           | 1                | 16.589 ns |  2.14 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise      | 1                | 18.938 ns |  2.44 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled (SyncCont) | 1                | 49.242 ns |  6.35 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled            | 1                | 51.358 ns |  6.62 |         - | 
|                                                      |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise      | 10               | 17.316 ns |  0.75 |         - | 
| SignalAndWait · CountdownEvent · System              | 10               | 20.321 ns |  0.87 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled            | 10               | 23.241 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise      | 10               | 29.339 ns |  1.26 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl           | 10               | 30.285 ns |  1.30 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled            | 10               | 65.343 ns |  2.81 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled (SyncCont) | 10               | 66.910 ns |  2.88 |         - |