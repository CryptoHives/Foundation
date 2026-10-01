| Description                                                | Iterations | Mean     | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          | 1.186 μs |  1.00 |     356 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          | 1.225 μs |  1.03 |     366 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          | 1.240 μs |  1.05 |     376 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          | 1.298 μs |  1.09 |    1004 B | 
|                                                            |            |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         | 1.280 μs |  0.95 |     372 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         | 1.295 μs |  0.96 |     381 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 1.353 μs |  1.00 |     411 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2.147 μs |  1.59 |    4093 B |