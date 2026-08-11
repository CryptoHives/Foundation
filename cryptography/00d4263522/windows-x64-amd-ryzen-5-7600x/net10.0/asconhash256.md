| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     592.0 ns |     3.45 ns |     3.23 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     792.0 ns |     3.09 ns |     2.89 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     612.3 ns |     3.12 ns |     2.77 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     833.2 ns |     1.26 ns |     1.05 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,749.2 ns |     8.36 ns |     6.99 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,150.2 ns |    11.07 ns |     9.24 ns |   6,798 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,759.2 ns |    14.10 ns |    12.50 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,143.2 ns |    10.92 ns |     9.11 ns |   6,798 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  29,066.9 ns |    82.71 ns |    77.37 ns |   5,739 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  40,029.8 ns |    85.74 ns |    71.60 ns |   6,791 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 464,041.0 ns | 1,309.02 ns | 1,160.41 ns |   5,681 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 635,356.1 ns |   954.54 ns |   745.24 ns |   6,793 B |         - |