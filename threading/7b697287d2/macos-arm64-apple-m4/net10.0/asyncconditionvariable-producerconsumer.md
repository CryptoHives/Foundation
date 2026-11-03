| Description                                                | Iterations | Mean     | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          | 1.159 μs |  1.00 |     356 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          | 1.165 μs |  1.01 |     365 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          | 1.239 μs |  1.07 |     368 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          | 1.323 μs |  1.14 |    1000 B | 
|                                                            |            |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         | 1.213 μs |  0.76 |     367 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         | 1.265 μs |  0.80 |     373 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 1.598 μs |  1.00 |     412 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2.069 μs |  1.30 |    4072 B |