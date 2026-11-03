| Description                                                | Iterations | Mean       | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |-----------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          |   506.1 ns |  0.97 |     364 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          |   506.9 ns |  0.97 |     372 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          |   520.7 ns |  1.00 |     357 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          |   614.8 ns |  1.18 |    1014 B | 
|                                                            |            |            |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         |   623.7 ns |  0.65 |     413 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         |   624.9 ns |  0.65 |     394 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         |   959.2 ns |  1.00 |     622 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2,641.2 ns |  2.75 |    5232 B |