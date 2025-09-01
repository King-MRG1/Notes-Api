using Microsoft.EntityFrameworkCore;
public class NoteContext : DbContext
{
    public NoteContext() { }
    public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<Note> Notes { get; set; }
}