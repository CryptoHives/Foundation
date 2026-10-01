| Description                                                | Iterations | Mean       | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |-----------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          |   521.0 ns |  0.98 |     370 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          |   523.3 ns |  0.98 |     366 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          |   533.0 ns |  1.00 |     356 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          |   597.6 ns |  1.12 |    1017 B | 
|                                                            |            |            |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         |   625.7 ns |  0.60 |     410 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         |   636.2 ns |  0.61 |     397 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 1,047.4 ns |  1.00 |     670 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2,340.0 ns |  2.23 |    5139 B |