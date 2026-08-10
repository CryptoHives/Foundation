| Description                                  | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 128B         |       114.4 ns |     0.42 ns |     0.39 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 128B         |       385.1 ns |     1.11 ns |     0.99 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 128B         |     1,276.6 ns |     5.00 ns |     4.68 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 137B         |       159.2 ns |     0.44 ns |     0.39 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 137B         |       448.0 ns |     1.42 ns |     1.32 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 137B         |     1,891.7 ns |     6.10 ns |     5.70 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 1KB          |       764.4 ns |     2.35 ns |     2.08 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 1KB          |     1,306.0 ns |     3.16 ns |     2.96 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 1KB          |     9,634.6 ns |    56.27 ns |    52.63 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 1025B        |       868.4 ns |     1.25 ns |     1.11 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 1025B        |     1,451.8 ns |     4.91 ns |     4.59 ns |     224 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 1025B        |    10,605.3 ns |    31.81 ns |    29.76 ns |     168 B |
|                                              |              |                |             |             |           |
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 8KB          |     1,195.4 ns |     5.78 ns |     5.13 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 8KB          |    10,392.2 ns |    33.82 ns |    31.64 ns |     896 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 8KB          |    79,738.4 ns |   212.97 ns |   199.21 ns |     504 B |
|                                              |              |                |             |             |           |
| ComputeHash | BLAKE3 | BLAKE3 (Native)       | 128KB        |    14,321.4 ns |    45.43 ns |    40.27 ns |     112 B |
| ComputeHash | BLAKE3 | BLAKE3 (Managed)      | 128KB        |   169,058.7 ns |   399.59 ns |   373.77 ns |   14336 B |
| ComputeHash | BLAKE3 | BLAKE3 (BouncyCastle) | 128KB        | 1,287,964.0 ns | 5,132.67 ns | 4,286.01 ns |    7224 B |