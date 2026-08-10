| Description                                  | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|--------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| TryComputeHash · Ascon-XOF128 · Managed      | 128B         |     573.9 ns |      5.01 ns |      4.18 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128B         |     764.9 ns |     11.42 ns |     10.13 ns |         - |
|                                              |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 137B         |     608.9 ns |     10.42 ns |      9.75 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 137B         |     801.8 ns |      6.42 ns |      5.69 ns |         - |
|                                              |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1KB          |   3,741.9 ns |     70.22 ns |     65.68 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1KB          |   4,954.6 ns |     83.53 ns |     78.14 ns |         - |
|                                              |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 1025B        |   3,747.0 ns |     50.01 ns |     46.78 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 1025B        |   4,926.9 ns |     46.99 ns |     41.65 ns |         - |
|                                              |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 8KB          |  28,987.4 ns |    505.25 ns |    447.89 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 8KB          |  38,618.1 ns |    744.02 ns |    695.96 ns |         - |
|                                              |              |              |              |              |           |
| TryComputeHash · Ascon-XOF128 · Managed      | 128KB        | 457,370.8 ns |  5,060.83 ns |  4,226.02 ns |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle | 128KB        | 618,939.6 ns | 11,905.87 ns | 11,693.16 ns |         - |