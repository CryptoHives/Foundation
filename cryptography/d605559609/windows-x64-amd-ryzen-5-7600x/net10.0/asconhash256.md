| Description                                         | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     575.2 ns |     2.49 ns |     2.21 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     781.6 ns |     4.75 ns |     3.97 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     606.9 ns |     3.60 ns |     3.01 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     821.5 ns |     3.41 ns |     3.19 ns |   6,807 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |   3,716.9 ns |    23.62 ns |    19.72 ns |   5,709 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |   5,083.7 ns |    22.25 ns |    19.73 ns |   6,798 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |   3,727.8 ns |    20.17 ns |    17.88 ns |   5,721 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |   5,079.7 ns |    17.87 ns |    16.72 ns |   6,798 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |  29,068.7 ns |   228.15 ns |   202.25 ns |   5,739 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |  39,412.3 ns |   392.98 ns |   328.16 ns |   6,801 B |         - |
|                                                     |              |              |             |             |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        | 460,104.8 ns | 2,122.51 ns | 1,772.39 ns |   5,681 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 629,943.8 ns | 4,774.86 ns | 4,466.41 ns |   6,793 B |         - |