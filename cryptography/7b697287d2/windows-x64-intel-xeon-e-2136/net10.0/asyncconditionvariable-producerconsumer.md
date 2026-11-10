| Description                                                | Iterations | Mean     | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          | 1.068 μs |  0.94 |     359 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          | 1.079 μs |  0.95 |     357 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          | 1.134 μs |  1.00 |     348 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          | 1.294 μs |  1.14 |     997 B | 
|                                                            |            |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         | 1.271 μs |  0.50 |     387 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         | 1.307 μs |  0.52 |     386 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 2.533 μs |  1.00 |     560 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 7.331 μs |  2.89 |    5446 B |