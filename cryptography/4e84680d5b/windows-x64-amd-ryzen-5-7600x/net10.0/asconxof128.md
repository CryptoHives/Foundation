| Description                                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 128B         |     789.9 ns |     7.41 ns |     6.93 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 128B         |     834.7 ns |     7.73 ns |     6.85 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 137B         |     824.7 ns |     4.26 ns |     3.99 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 137B         |     883.6 ns |     5.12 ns |     4.79 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 1KB          |   4,918.2 ns |    35.47 ns |    31.44 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 1KB          |   4,939.3 ns |    17.73 ns |    15.71 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 1025B        |   4,936.2 ns |    38.85 ns |    36.34 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 1025B        |   4,972.9 ns |    47.74 ns |    44.66 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 8KB          |  37,606.4 ns |   288.14 ns |   255.43 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 8KB          |  38,205.5 ns |   339.11 ns |   317.20 ns |     112 B |
|                                                          |              |              |             |             |           |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (Managed)      | 128KB        | 598,578.8 ns | 5,119.20 ns | 4,538.04 ns |     112 B |
| ComputeHash · Ascon-XOF128 · Ascon-XOF128 (BouncyCastle) | 128KB        | 619,799.8 ns | 2,907.62 ns | 2,719.79 ns |     112 B |